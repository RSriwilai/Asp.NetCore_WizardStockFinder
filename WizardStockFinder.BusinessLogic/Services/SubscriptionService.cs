using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.DataAccess.Interfaces;
using WizardStockFinder.DataAccess.Models;
using WizardStockFinder.Models.SubscriptionModels;

namespace WizardStockFinder.BusinessLogic.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> CreateSubscription(CreateSubscriptionModel model)
        {
            var subscription = new Subscription
            {
                Username = model.Username,
                Email = model.Email,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                AccountId = new ObjectId(model.AccountId)
            };

            return await _subscriptionRepository.CreateSubscription(subscription);
        }
    }
}
