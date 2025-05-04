namespace eCommerce.Core.Validators;

using eCommerce.Core.DTO;
using FluentValidation;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");
        
        //Password
        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required");
        
        //PersonName
        RuleFor(temp => temp.PersonName)
            .NotEmpty().WithMessage("Name can't be blank")
            .MaximumLength(50).WithMessage("Name can't exceed 50 characters");
        
        //Gender
        RuleFor(temp => temp.Gender)
            .NotEmpty().WithMessage("Gender is required")
            .IsInEnum().WithMessage("Gender is invalid");
    }
}