using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.Models.SubscriptionModels
{
    public class CreateSubscriptionModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountId { get; set; }
    }
}
