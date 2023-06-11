using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.Models.AccountModels
{
    public class AccountAuthorizationData
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
    }
}
