using MongoDB.Bson;
using MongoDB.Driver;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.DataAccess.Interfaces;
using WizardStockFinder.DataAccess.Models;

namespace WizardStockFinder.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IMongoCollection<Account> _accountCollection;
    private readonly IMongoCollection<Subscription> _subscriptionCollection;

    public AccountRepository(WizardStockFinderDbContext dbContext)
    {
        _accountCollection = dbContext.GetCollection<Account>("accounts");
        _subscriptionCollection = dbContext.GetCollection<Subscription>("subscriptions");
    }

    public async Task<List<Account>> GetAll()
    {
        return await _accountCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Account> CreateAccount(Account account)
    {
        await _accountCollection.InsertOneAsync(account);
        return account;
    }

    public Account GetAccountByUsername(string username)
    {
        var filter = Builders<Account>.Filter.Eq(x => x.Username, username);
        return _accountCollection.Find(filter).FirstOrDefault();
    }

    public Account GetAccountByEmail(string email)
    {
        var filter = Builders<Account>.Filter.Eq(x => x.Email, email);
        return _accountCollection.Find(filter).FirstOrDefault();
    }

    public void LinkAccountToSubscription(ObjectId accountId, ObjectId subscriptionId)
    {
        var accountFilter = Builders<Account>.Filter.Eq(x => x.Id, accountId);
        var subscriptionFilter = Builders<Subscription>.Filter.Eq(x => x.Id, subscriptionId);

        var accountUpdate = Builders<Account>.Update.Set(x => x.SubscriptionId, subscriptionId);
        var subscriptionUpdate = Builders<Subscription>.Update.Set(x => x.AccountId, accountId);

        _accountCollection.UpdateOne(accountFilter, accountUpdate);
        _subscriptionCollection.UpdateOne(subscriptionFilter, subscriptionUpdate);
    }

}