using EmployCheck.Application.Repository;

namespace EmployCheck.Application.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IEmployCheckRepository _employCheckRepository;

    public IEmployCheckRepository EmployCheckRepository
    {
        get { return _employCheckRepository ??= new EmployCheckRepository(context); }
    }

    public async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}