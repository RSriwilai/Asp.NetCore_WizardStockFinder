using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.DataAccess.Models
{
    public class Account
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public Enums.AccountRole AccountRole { get; set; } = Enums.AccountRole.User;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public DateTime? ValidUntil { get; set; } 
        public bool IsLockedOut { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public ObjectId SubscriptionId { get; set; } = ObjectId.Empty;
        public ObjectId ContactId { get; set; } = ObjectId.Empty;

    }
}
