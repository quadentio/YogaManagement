using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YogaManagement.Validator
{
    public static class ValidationResultExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            // Clear model binding function in asp.net core
            modelState.Clear();

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
        }
    }
}