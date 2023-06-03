using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WizardStockFinder.DataAccess.Models;

namespace WizardStockFinder.DataAccess.DataContext
{
    public class WizardStockFinderDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public WizardStockFinderDbContext() { }

        public WizardStockFinderDbContext(DbContextOptions<WizardStockFinderDbContext> options) : base(options) { }
    }
}
