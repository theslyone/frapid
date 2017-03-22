﻿using Moneywave.Net;
using Moneywave.Net.Models;
using Moneywave.Net.Requests;
using System;
using System.Linq;
using Xunit;

namespace Moneywave.Net.Test
{
    public class MoneywaveFixture : IDisposable
    {
        public MoneywaveFixture()
        {
            Api = new MoneywaveApi("ts_KZ1HPL6JRGJK2J08FB44", "ts_H8HVTV6LR6LMZT42PI6KJVGNA9HIMZ", ClientMode.Test);
        }

        public void Dispose()
        {
            
        }

        public MoneywaveApi Api { get; private set; }
    }

    public sealed class ApiTests : IClassFixture<MoneywaveFixture>
    {
        MoneywaveApi Api; 
        public ApiTests(MoneywaveFixture fixture)
        {
            this.Api = fixture.Api;
        }

        [Fact]
        public void GetBanks()
        {
            var banks = Api.GetBanks();
            Assert.Equal(banks.Count, 29);
        }

        [Fact]
        public void GetCharge()
        {
            ChargeRequest request = new ChargeRequest { Amount = 100, Fee = 70 };
            var charge = Api.Transactions.GetCharge(request);
            Assert.Equal(charge.AmountToSend + charge.MerchantCommission, request.Amount + request.Fee);
        }

        [Fact]
        public void ValidateAccount()
        {
            string accountName = Api.Accounts.Validate("0921318712", "058");
            Assert.IsType<string>(accountName);
            Assert.True(!string.IsNullOrEmpty(accountName));
            accountName = Api.Accounts.Validate("0690000004", "044");
            Assert.IsType<string>(accountName);
            Assert.True(!string.IsNullOrEmpty(accountName));
            Assert.Throws<MoneywaveException>(() => Api.Accounts.Validate("0137745981", "058"));
        }

        [Fact]
        public void TokenizeCard()
        {
            Card card = new Card { CardNumber = "4960092279520867", Cvv= "922", ExpiryMonth = "12", ExpiryYear= "18" };
            var token = Api.Cards.Tokenize(card);
            Assert.IsType<string>(token);
            Assert.Matches("^.{1,}$", token);
        }

        [Fact]
        public void Transfer()
        {
            Card card = new Card
            {
                CardNumber =  "5455844437306780",// "5061020000000000094"
                Cvv = "373",
                ExpiryMonth = "06",
                ExpiryYear = "19"
            };

            var cardDetails = Api.Cards.Validate(card.CardNumber);

            TransferRequest request = new TransferRequest();
            request.FirstName = "Sylvester";
            request.LastName = "Okonkwo";
            request.PhoneNumber = "+2348030469664";
            request.Email = "theslyguy@icloud.com";
            request.Recipient = RecipientType.Account;
            request.RecipientBank = "058";
            request.RecipientAccountNumber = "0921318712";
                                  
            /*request.CardNumber = card.CardNumber;
            request.Cvv = card.Cvv;
            request.ExpiryMonth = card.ExpiryMonth;
            request.ExpiryYear = card.ExpiryYear;
            */
            var token = Api.Cards.Tokenize(card);
            request.CardToken = token;

            request.ChargeWith = ChargeType.TokenizedCard;

            request.Pin = "1111";
            request.Amount = 10;
            request.Fee = 0;
            request.RedirectUrl = "https://freebe.ngrok";
            request.Medium = "mobile";

            request.SenderAccountNumber = "0690000005";
            request.SenderBank = "044";
            request.ChargeAuth = "PIN";
            
            
            var response = Api.Transactions.Transfer(request);
            Assert.Equal(request.RecipientAccountNumber, response.Transfer.Beneficiary.AccountNumber);
            //Assert.Equal(request.SenderAccountNumber, response.Transfer.Account.AccountNumber);
            Assert.IsType<string>(response.Transfer.FlutterChargeReference);
            Assert.Matches("^.{1,}$", response.Transfer.FlutterChargeReference);


            var reference = response.Transfer.FlutterChargeReference;
            var transfer = Api.Transactions.ValidateTransfer(ChargeType.Card, reference, "123456", Transactions.AuthType.OTP);
            transfer = Api.Transactions.Get(transfer.Id);              
        }


        [Fact]
        public void Disburse()
        {
            DisburseRequest request = new DisburseRequest();
            request.SenderName = "Okonkwo Sylvester";
            request.BankCode = "058";
            request.AccountNumber = "0921318712";
            request.Amount = 10;
            request.Ref = "TMW000000317";
            request.Lock = "0987654321";

            Assert.Throws<MoneywaveException>(() => Api.Transactions.Disburse(request));
            //var response = Api.Transactions.Disburse(request);
        }
    }
}
