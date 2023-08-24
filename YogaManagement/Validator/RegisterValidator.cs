using FluentValidation;
using YogaManagement.Common;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username must not be empty");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty")
                .Matches(Const.PASSWORD_REGEX)
                .WithMessage("Password should contain at least 1 number, uppercase, special character");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Confirm password must not be empty")
                .Must((obj, _) => obj.ConfirmPassword == obj.Password)
                .WithMessage("Confirm password must match with password");
        }
    }
}
