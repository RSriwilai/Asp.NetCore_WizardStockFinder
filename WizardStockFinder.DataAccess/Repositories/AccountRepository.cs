using Microsoft.EntityFrameworkCore;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.DataAccess.Interfaces;
using WizardStockFinder.DataAccess.Models;

namespace WizardStockFinder.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly WizardStockFinderDbContext _db;

    public AccountRepository(WizardStockFinderDbContext db)
    {
        _db = db;
    }

    public async Task<List<Account>> GetAll()
    {
        return await _db.Accounts.ToListAsync();
    }
}