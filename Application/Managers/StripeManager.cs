using Domain.Entities;
using Domain.Interfaces.Application;
using Stripe;
using System.Threading.Tasks;

namespace Application.Managers
{
    public class StripeManager : IStripeManager
    {
        public Task CreatePayment(Payment payment)
        {
            var chargeService = new ChargeService();


            var options = new ChargeCreateOptions();
            RequestOptions options1 = new RequestOptions
            {
                ApiKey = "sk_test_51Gue6sFrQWpIfAvdAISJAHDL3p9HgPznldqrplt87ufPpvDur2d9KXXo3SJc1PX8wxkqR5fhE1OvjK6uXBeOg0pC00tOQXLzV5"
            };
            StripeConfiguration.ApiKey = "sk_test_51Gue6sFrQWpIfAvdAISJAHDL3p9HgPznldqrplt87ufPpvDur2d9KXXo3SJc1PX8wxkqR5fhE1OvjK6uXBeOg0pC00tOQXLzV5";
            

            options.Source = payment.Source;
            options.Amount = payment.Amount;
            options.Currency = "usd";

            return chargeService.CreateAsync(options);
        }
    }
}
