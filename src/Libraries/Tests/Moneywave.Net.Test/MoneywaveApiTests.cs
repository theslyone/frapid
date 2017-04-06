using Moneywave.Net;
using Moneywave.Net.Models;
using Moneywave.Net.Requests;
using Moneywave.Net.Responses;
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

    public sealed class MoneywaveApiTests : IClassFixture<MoneywaveFixture>
    {
        MoneywaveApi Api; 
        public MoneywaveApiTests(MoneywaveFixture fixture)
        {
            this.Api = fixture.Api;
        }

        [Fact]
        public void GetBanks()
        {
            var banks = Api.GetBanks();
            Assert.NotEmpty(banks);
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
        public void TransferToAccount()
        {
            Card card = new Card
            {
                CardNumber = "5314992834267591",
                Cvv = "342",
                ExpiryMonth = "09",
                ExpiryYear = "19"
            };

            card = new Card
            {
                CardNumber = "5061020000000000094",
                Cvv = "931",
                ExpiryMonth = "03",
                ExpiryYear = "18"
            };

            var cardDetails = Api.Cards.Validate(card.CardNumber);

            TransferRequest request = new TransferRequest();
            request.FirstName = "Sylvester";
            request.LastName = "Okonkwo";
            request.PhoneNumber = "+2348030469664";
            request.Email = "theslyguy@icloud.com";
            request.Recipient = RecipientType.Account;
            request.RecipientBank = "044";
            request.RecipientAccountNumber = "0690000004";
            /*                      
            request.CardNumber = card.CardNumber;
            request.Cvv = card.Cvv;
            request.ExpiryMonth = card.ExpiryMonth;
            request.ExpiryYear = card.ExpiryYear;
            */
            var token = Api.Cards.Tokenize(card);
            request.CardToken = token;

            request.ChargeWith = ChargeType.TokenizedCard;
            request.Pin = "1111";
            request.ChargeAuth = "PIN";
       
            request.Amount = 3500;
            request.Fee = 0;
            request.RedirectUrl = "https://freebe.ngrok";
            request.Medium = "mobile";
            
            var response = Api.Transactions.Transfer(request);
            Assert.Equal(request.RecipientAccountNumber, response.Transfer.Beneficiary.AccountNumber);
            Assert.IsType<string>(response.Transfer.FlutterChargeReference);
            Assert.Matches("^.{1,}$", response.Transfer.FlutterChargeReference);

            if (response.PendingValidation)
            {
                var reference = response.Transfer.FlutterChargeReference;
                Transfer transfer = Api.Transactions.ValidateTransfer(ChargeType.Card, reference, "123456", Transactions.AuthType.OTP);
                transfer = Api.Transactions.Get(response.Transfer.Id);
                Assert.Equal(transfer.FlutterChargeResponseCode, "00");
            }
        }        

        [Fact]
        public void TransferToWallet()
        {
            Card card = new Card
            {
                CardNumber = "5314992834267591",
                Cvv = "342",
                ExpiryMonth = "09",
                ExpiryYear = "19"
            };

            card = new Card
            {
                CardNumber = "5061020000000000094", 
                Cvv = "931",
                ExpiryMonth = "03",
                ExpiryYear = "18"
            };

            var cardDetails = Api.Cards.Validate(card.CardNumber);

            TransferRequest request = new TransferRequest();
            request.FirstName = "Sylvester";
            request.LastName = "Okonkwo";
            request.PhoneNumber = "+2348030469664";
            request.Email = "theslyguy@icloud.com";
            request.Recipient = RecipientType.Wallet;

            var token = Api.Cards.Tokenize(card);
            request.CardToken = token;

            request.ChargeWith = ChargeType.TokenizedCard;
            request.Pin = "1111";
            request.ChargeAuth = "PIN";

            request.Amount = 30000;
            request.Fee = 0;
            request.RedirectUrl = "https://freebe.ngrok";
            request.Medium = "mobile";
            
            var response = Api.Transactions.Transfer(request);
            Assert.IsType<string>(response.Transfer.FlutterChargeReference);
            Assert.Matches("^.{1,}$", response.Transfer.FlutterChargeReference);

            if(response.PendingValidation)
            {
                var reference = response.Transfer.FlutterChargeReference;
                Transfer transfer = Api.Transactions.ValidateTransfer(ChargeType.Card, reference, "123456", Transactions.AuthType.OTP);
                transfer = Api.Transactions.Get(response.Transfer.Id);
                Assert.Equal(transfer.FlutterChargeResponseCode, "00");
            }
        }

        [Fact]
        public void TransferStatus()
        {
            var response = Api.Transactions.Get("6045");
            Assert.Equal(response.FlutterChargeResponseCode, "00");
        }

        [Fact]
        public void Disburse()
        {
            DisburseRequest request = new DisburseRequest();
            request.SenderName = "Okonkwo Sylvester";
            request.BankCode = "044";
            request.AccountNumber = "0690000005";
            //request.BankCode = "058";
            //request.AccountNumber = "0921318712";
            request.Amount = 40;
            request.Ref = $"TMW{KeyGenerator.GetUniqueAlphaNumericCode(10)}";
            request.Lock = "*Passw0rd#";
            DisburseResponse response = response = Api.Transactions.Disburse(request);
            Assert.Equal("00", response.Data.ResponseCode);
        }
    }
}
