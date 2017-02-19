using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using PayStack.Net;

namespace Frapid.Twilio
{
    public class Class1
    {
        static void Main(string[] args)
        {
            /*var accountSid = "AC03307b96226a99c549bb30ee6e13af34"; // Your Account SID from www.twilio.com/console
            var authToken = "6094bf45e27b90f18168a272c3a9a216";  // Your Auth Token from www.twilio.com/console

            var twilio = new TwilioRestClient(accountSid, authToken);
            var message = twilio.SendMessage(
                "+8613101515823", // From (Replace with your Twilio number)
                "+8613101515823", // To (Replace with your phone number)
                "What's up oldie"
                );
            Console.WriteLine(message.Sid);
            */
            var api = new PayStackApi("sk_test_8fc4d1da50f1bab3ee8d41f2b210eed0fed602e0");
            var request = new CustomerCreateRequest { Email="idontknow@harbin.com" };
            var response = api.Customers.Create(request);
            Console.WriteLine(response.Status + " " + response.Message);

            var listResponse = api.Customers.List();
            Console.WriteLine(listResponse);

            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
