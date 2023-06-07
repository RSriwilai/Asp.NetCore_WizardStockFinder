using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.Models.StockHandlerProcessorModels;

namespace WizardStockFinder.Models.StockDataModels.SupportResistanceModels
{
    public class StockDataWithSupportResistanceDto
    {
        public StockData StockData { get; set; }
        public List<decimal> SupportLevels { get; set; }
        public List<decimal> ResistanceLevels { get; set; }
    }
}
