using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.DataAccess.Models;

namespace WizardStockFinder.DataAccess.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<bool> CreateSubscription(Subscription subscription);
    }
}
