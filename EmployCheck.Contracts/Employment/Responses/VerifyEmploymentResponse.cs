namespace EmployCheck.Contracts.Employment.Responses;

public class VerifyEmploymentResponse
{
    public bool IsEmploymentVerified { get; set; }
    public string? Message { get; set; }
}