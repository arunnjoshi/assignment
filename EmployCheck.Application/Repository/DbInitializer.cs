using Microsoft.EntityFrameworkCore;

namespace EmployCheck.Application.Repository;

public class DbInitializer(AppDbContext context)
{
    public async Task InitializeAsync()
    {
        var sqlScript = await File.ReadAllTextAsync("../EmployCheck.Application/DbScripts/DbUp.sql");
        await context.Database.ExecuteSqlRawAsync(sqlScript);
        Console.WriteLine("SQL script executed successfully.");
    }
}