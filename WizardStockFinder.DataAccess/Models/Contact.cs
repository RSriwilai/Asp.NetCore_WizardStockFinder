using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.DataAccess.Models
{
    public class Contact
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Enums.AlertType AlertType { get; set; }

        public ObjectId AccountId { get; set; } = ObjectId.Empty;
    }
}
