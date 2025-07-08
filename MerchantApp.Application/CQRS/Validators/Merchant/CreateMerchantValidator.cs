using FluentValidation;
using MerchantApp.Application.CQRS.Commands;

namespace MerchantApp.Application.CQRS.Validators.Merchant;
public class CreateMerchantCommandValidator : AbstractValidator<CreateMerchantCommand>
{
    public CreateMerchantCommandValidator()
    {
        RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email is required.")
                 .EmailAddress().WithMessage("A valid email address is required.")
                 .MaximumLength(100).WithMessage("Email address must not exceed 100 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character (e.g., ! @ # ?).");

        RuleFor(x => x.BusinessName)
            .NotEmpty().WithMessage("Business name is required.")
            .MaximumLength(100).WithMessage("Name of the contact person must not exceed 100 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{10,15}$").WithMessage("Phone number must contain 10 to 15 digits.");

    }
}

