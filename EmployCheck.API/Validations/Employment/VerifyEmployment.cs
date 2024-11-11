using System.Data;
using EmployCheck.Contracts.Employment.Requests;
using FluentValidation;

namespace EmployCheck.API.Validations.Employment;

public class VerifyEmployment : AbstractValidator<VerifyEmploymentRequest>
{
    public VerifyEmployment()
    {
        RuleFor(x => x.EmployeeId).Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Employee ID cannot be null or empty.")
            .GreaterThan(0)
            .WithMessage("Employee ID must be greater than 0.");

        RuleFor(x => x.Companyname)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .WithMessage("Companyname cannot be null or empty.")
            .MinimumLength(3)
            .WithMessage("Companyname must be at least 3 characters.")
            .MaximumLength(20)
            .WithMessage("Companyname must be less than 20 characters.");

        RuleFor(x => x.VerificationCode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .WithMessage("Verification code cannot be null or empty.")
            .MinimumLength(3)
            .WithMessage("Verification code must be at least 3 characters.")
            .MaximumLength(6)
            .WithMessage("Verification code must be less than 6 characters.");
    }
}