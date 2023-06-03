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
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string? Email { get; set; }
        public Enums.AccountRole AccountRole { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool IsLockedOut { get; set; } 
        public bool IsDeleted { get; set; } 
        public int ContactId { get; set; }


        public virtual Contact Contact { get; set; }

    }
}
