using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.DataAccess.Models;
using WizardStockFinder.Models.SubscriptionModels;

namespace WizardStockFinder.BusinessLogic.Interfaces
{
    public interface ISubscriptionService
    {
        Task<bool> CreateSubscription(CreateSubscriptionModel subscription);
    }
}
