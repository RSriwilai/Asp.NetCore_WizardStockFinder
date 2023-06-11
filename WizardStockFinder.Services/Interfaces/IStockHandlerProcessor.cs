using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.Services.Interfaces
{
    public interface IStockHandlerProcessor
    {
        Task ExecuteAsync();
    }
}
