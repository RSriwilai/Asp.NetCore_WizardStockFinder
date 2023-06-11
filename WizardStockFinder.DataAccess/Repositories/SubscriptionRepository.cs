using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.DataAccess.Interfaces;
using WizardStockFinder.DataAccess.Models;

namespace WizardStockFinder.DataAccess.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IMongoCollection<Subscription> _subscriptionCollection;
        private readonly IMongoCollection<Account> _accountCollection;

        public SubscriptionRepository(WizardStockFinderDbContext dbContext)
        {
            _subscriptionCollection = dbContext.GetCollection<Subscription>("subscriptions");
            _accountCollection = dbContext.GetCollection<Account>("accounts");

        }


        public async Task<bool> CreateSubscription(Subscription subscription)
        {
            try
            {
                await _subscriptionCollection.InsertOneAsync(subscription);
                await LinkAccountToSubscription(subscription.AccountId, subscription.Id);

                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        public async Task<bool> UnsubscribeAccount(ObjectId accountId)
        {
            try
            {
                var subscriptionFilter = Builders<Subscription>.Filter.Eq(x => x.AccountId, accountId);
                var accountFilter = Builders<Account>.Filter.Eq(x => x.Id, accountId);

                var accountUpdate = Builders<Account>.Update
                    .Set(x => x.SubscriptionId, ObjectId.Empty)
                    .Set(x => x.AccountRole, Enums.AccountRole.User);

                await _subscriptionCollection.DeleteOneAsync(subscriptionFilter);
                await _accountCollection.UpdateOneAsync(accountFilter, accountUpdate);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private async Task LinkAccountToSubscription(ObjectId accountId, ObjectId subscriptionId)
        {
            var accountFilter = Builders<Account>.Filter.Eq(x => x.Id, accountId);
            var subscriptionFilter = Builders<Subscription>.Filter.Eq(x => x.Id, subscriptionId);

            var accountUpdate = Builders<Account>.Update
                .Set(x => x.SubscriptionId, subscriptionId)
                .Set(x => x.AccountRole, Enums.AccountRole.Vip);

            var subscriptionUpdate = Builders<Subscription>.Update.Set(x => x.AccountId, accountId);

            await _accountCollection.UpdateOneAsync(accountFilter, accountUpdate);
            await _subscriptionCollection.UpdateOneAsync(subscriptionFilter, subscriptionUpdate);
        }
    }
}
