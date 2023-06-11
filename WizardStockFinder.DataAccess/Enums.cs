using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardStockFinder.DataAccess
{
    public static class Enums
    {
        public enum AccountRole
        {
            Admin = 1,
            User,
            Vip
        }

        public enum AlertType
        {
            Undefined = 0,
            Email,
            Sms,
            EmailAndSms
        }

    }
}
