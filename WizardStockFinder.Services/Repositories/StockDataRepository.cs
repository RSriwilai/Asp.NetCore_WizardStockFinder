using MongoDB.Bson;
using MongoDB.Driver;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.Models.StockHandlerProcessorModels;
using WizardStockFinder.Services.Repositories.Interfaces;

namespace WizardStockFinder.Services.Repositories
{
    public class StockDataRepository : IStockDataRepository
    {
        private readonly IMongoCollection<StockData> _stockDataCollection;

        public StockDataRepository(WizardStockFinderDbContext dbContext)
        {
            _stockDataCollection = dbContext.GetCollection<StockData>("stockData");
        }

        public async Task InsertData(StockData data, string symbol, string interval)
        {
            var filter = Builders<StockData>.Filter.Eq(x => x.MetaData.Symbol, symbol) & Builders<StockData>.Filter.Eq(x => x.MetaData.Interval, interval);
            await _stockDataCollection.DeleteOneAsync(filter);

            await _stockDataCollection.InsertOneAsync(data);
        }

        public async Task<StockData> GetData(string symbol, string interval)
        {
            var filter = Builders<StockData>.Filter.Eq(x => x.MetaData.Symbol, symbol) & Builders<StockData>.Filter.Eq(x => x.MetaData.Interval, interval);
            var stockData = await _stockDataCollection.Find(filter).FirstOrDefaultAsync();

            return stockData;
        }

    }
}
