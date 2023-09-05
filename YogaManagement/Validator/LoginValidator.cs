using FluentValidation;
using YogaManagement.Common;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Validator
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username must not be empty");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty")
                .Matches(Const.PASSWORD_REGEX)
                .WithMessage("Password should contain at least 1 number, uppercase, special character");
        }
    }
}
