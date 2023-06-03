using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WizardStockFinder.DataAccess;

namespace WizardStockFinder.Models.AccountModels
{
    public class AccountAuthDto
    {
        public int AccountId { get; set; }
        public Enums.AccountRole Role { get; set; }
        public IPAddress IpAddress { get; set; }

    }
}
