using Data.Models;
using FluentValidation;

namespace YogaManagement.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username must not be empty");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty")
                .Matches(@"^(?=.*\d)(?=.*[A-Z])(?=.*[\W_]).+$")
                .WithMessage("Password should contain at least 1 number, uppercase, special character");
        }
    }
}
