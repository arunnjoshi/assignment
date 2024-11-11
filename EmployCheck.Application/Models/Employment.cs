namespace EmployCheck.Application.Models;

public class Employment
{
    public int EmployeeId { get; set; }
    public string Companyname { get; set; } = null!;
    public string VerificationCode { get; set; } = null!;
}