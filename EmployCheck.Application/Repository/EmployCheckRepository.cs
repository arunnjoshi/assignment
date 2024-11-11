using EmployCheck.Application.Models;

namespace EmployCheck.Application.Repository;

public class EmployCheckRepository : IEmployCheckRepository
{
    public Task<bool> VerifyEmployment(Employment employment)
    {
        return Task.FromResult(true);
    }

    public Task<bool> IsEmploymentVerified(int id)
    {
        return Task.FromResult(true);
    }
}