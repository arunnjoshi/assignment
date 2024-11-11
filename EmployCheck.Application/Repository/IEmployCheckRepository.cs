using EmployCheck.Application.Models;

namespace EmployCheck.Application.Repository;

public interface IEmployCheckRepository
{
    Task<bool> VerifyEmployment(Employment employment);
    Task<bool> IsEmploymentVerified(int id);
}