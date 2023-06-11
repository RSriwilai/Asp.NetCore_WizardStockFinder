using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace WizardStockFinder.DataAccess.Models
{
    public class Subscription
    {
        public ObjectId Id { get; set; }
        public string SubscriberName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ObjectId AccountId { get; set; }
    }
}
