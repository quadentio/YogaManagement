using FluentValidation;
using System.Runtime.CompilerServices;
using YogaManagement.Common;

namespace YogaManagement.Validator
{
    public static class RuleBuilderExtension
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessageAsync<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Task<string> error)
        {
            return rule.WithMessage(error.Result);
        }

        public static IRuleBuilder<TModel, string> IsPassword<TModel>(this IRuleBuilder<TModel, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("")
                .Matches(Const.PASSWORD_REGEX).WithMessage("");

            return options;
        }
    }
}
