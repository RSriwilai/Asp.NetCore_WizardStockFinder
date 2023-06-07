using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WizardStockFinder.Models.StockHandlerProcessorModels;

namespace WizardStockFinder.Utilis.Helpers
{
    public class JsonFileHelper
    {
        public static void WriteToStockDataJson(string jsonString)
        {
            string filePath = @"..\WizardStockFinder.DataAccess\StockData\stockData.json";
            File.WriteAllText(filePath, jsonString);
        }

        public static StockData ReadFromStockDataJson()
        {
            string filePath = @"..\WizardStockFinder.DataAccess\StockData\stockData.json";
            string json = File.ReadAllText(filePath);

            var stockData = JsonConvert.DeserializeObject<StockData>(json);

            return stockData;
        }
    }
}
