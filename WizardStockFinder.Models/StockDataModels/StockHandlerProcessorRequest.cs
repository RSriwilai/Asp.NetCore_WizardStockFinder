namespace WizardStockFinder.Models.StockHandlerProcessorModels
{
    public class StockHandlerProcessorRequest
    {
        public string TimeSeries { get; set; }
        public string Symbol { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
    }
}
