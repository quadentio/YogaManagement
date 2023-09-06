using FluentValidation;
using YogaManagement.Common;
using YogaManagement.ViewModel.Class;

namespace YogaManagement.Validator
{
    public class ClassValidator : AbstractValidator<ClassViewModel>
    {
        public ClassValidator()
        {
            RuleFor(x => x.ClassName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Class Name must not be empty.");

            RuleFor(x => x.ClassType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Please select class type.")
                .Must((obj, _) => ValidateClassType(obj.ClassType))
                .WithMessage("Class Type is not valid, please re-select.");

            RuleFor(x => x.MonthPeriod)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Please select month period.")
                .Must((obj, _) => ValidateMonthPeriod(obj.MonthPeriod))
                .WithMessage("Month Period is not valid, please re-select.");
        }

        /// <summary>
        /// Validate class type
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        private bool ValidateClassType(string classType)
        {
            DaysInWeek result;
            if (!Enum.TryParse(classType, out result))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate month period
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private bool ValidateMonthPeriod(string month)
        {
            int result;
            if (!int.TryParse(month, out result))
            {
                return false;
            }

            if (result < 1 || result > 12)
            {
                return false;
            }

            return true;
        }
    }
}
