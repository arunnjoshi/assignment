using EmployCheck.Application.Repository;

namespace EmployCheck.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IEmployCheckRepository EmployCheckRepository { get; }
    Task<int> CompleteAsync();
}