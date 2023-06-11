using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Bson;
using WizardStockFinder.DataAccess;
using WizardStockFinder.DataAccess.Models;

namespace WizardStockFinder.Models.AccountModels
{
    public class AccountDto
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public Enums.AccountRole AccountRole { get; set; }
        public DateTime CreatedOn { get; set; }

        public static AccountDto FromModel(Account model)
        {
            return new AccountDto
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                AccountRole = model.AccountRole,
                CreatedOn = model.CreatedOn,
            };
        }

        public Account ToModel()
        {
            return new Account
            {
                Id = Id,
                Username = Username,
            };
        }
    }


}
