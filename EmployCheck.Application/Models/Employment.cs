namespace EmployCheck.Application.Models;

public class Employment
{
    public int EmployeeId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string VerificationCode { get; set; } = null!;
    public bool IsEmploymentVerified { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? VerifiedOn { get; set; }
}