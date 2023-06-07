using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.BusinessLogic.Interfaces;
using WizardStockFinder.Models.StockDataModels.SupportResistanceModels;
using WizardStockFinder.Models.StockHandlerProcessorModels;
using WizardStockFinder.Utilis.Helpers;

namespace WizardStockFinder.BusinessLogic.Indicators
{
    public class SupportResistanceIndicator : ISupportResistanceIndicator
    {
        public async Task<StockDataWithSupportResistanceDto> CalculateSupportResistance()
        {
            var stockData = JsonFileHelper.ReadFromStockDataJson();
            List<decimal> supportLevels = await CalculateSupportLevels(stockData.TimeSeries);
            List<decimal> resistanceLevels = await CalculateResistanceLevels(stockData.TimeSeries);

            return new StockDataWithSupportResistanceDto()
            {
                StockData = stockData,
                SupportLevels = supportLevels,
                ResistanceLevels = resistanceLevels
            };
        }


        private Task<List<decimal>> CalculateSupportLevels(Dictionary<string,TimeSeriesData> timeSeries)
        {
            List<decimal> supportLevels = new List<decimal>();

            List<decimal> lows = timeSeries.Values.Select(x => x.Low).ToList();

            decimal currentLow = lows[0];
            decimal previousLow = currentLow;
            int count = 0;

            foreach (decimal low in lows)
            {
                if (low < currentLow)
                {
                    previousLow = currentLow;
                    currentLow = low;
                    count = 1;
                }
                else if (low == currentLow)
                {
                    count++;
                }

                if (count >= 3)
                {
                    supportLevels.Add(currentLow);
                    count = 0;
                }
            }

            return Task.FromResult(supportLevels);
        }

        private Task<List<decimal>> CalculateResistanceLevels(Dictionary<string, TimeSeriesData> timeSeries)
        {
            List<decimal> resistanceLevels = new List<decimal>();

            List<decimal> highs = timeSeries.Values.Select(x => x.High).ToList();

            decimal currentHigh = highs[0];
            decimal previousHigh = currentHigh;
            int count = 0;

            foreach (decimal high in highs)
            {
                if (high > currentHigh)
                {
                    previousHigh = currentHigh;
                    currentHigh = high;
                    count = 1;
                }
                else if (high == currentHigh)
                {
                    count++;
                }

                if (count >= 3)
                {
                    resistanceLevels.Add(currentHigh);
                    count = 0;
                }
            }

            return Task.FromResult(resistanceLevels);
        }

    }
}

