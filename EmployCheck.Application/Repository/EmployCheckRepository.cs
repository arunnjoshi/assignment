using EmployCheck.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployCheck.Application.Repository;

public class EmployCheckRepository : IEmployCheckRepository
{
    private readonly AppDbContext _appDbContext;

    public EmployCheckRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> VerifyEmployment(Employment employment)
    {
        var emp = await _appDbContext.Employment.FirstOrDefaultAsync(x =>
            x.EmployeeId == employment.EmployeeId
            && x.VerificationCode == employment.VerificationCode);
        if (emp == null) return false;
        emp.IsEmploymentVerified = true;
        emp.VerifiedOn = DateTime.Now;
        return true;
    }

    public async Task<bool> IsEmploymentVerified(int id)
    {
        return await _appDbContext.Employment.AnyAsync(x => x.EmployeeId == id && x.IsEmploymentVerified == true);
    }
}