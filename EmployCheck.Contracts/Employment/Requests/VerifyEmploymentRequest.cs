namespace EmployCheck.Contracts.Employment.Requests;

public class VerifyEmploymentRequest
{
    public int EmployeeId { get; set; }
    public string Companyname { get; set; } = null!;
    public string VerificationCode { get; set; } = null!;
}