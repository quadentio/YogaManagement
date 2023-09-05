using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using YogaManagement.ViewModel;

namespace YogaManagement.Validator
{
    public static class ValidationResultExtension
    {
        /// <summary>
        /// Normal MVC validation
        /// </summary>
        /// <param name="result"></param>
        /// <param name="modelState"></param>
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

        /// <summary>
        /// AJAX application validation
        /// </summary>
        /// <param name="result"></param>
        /// <param name="model"></param>
        public static void AddToErrorViewModel(this ValidationResult result, BaseViewModel model)
        {
            if (!result.IsValid)
            {
                foreach (var error in result.Errors.GroupBy(x => x.PropertyName))
                {
                    model.Errors.Add(new ErrorViewModel() {
                        Key = error.Key,
                        Messages = error.Select(x => x.ErrorMessage).ToList()
                    });
                }
            }
        }
    }
}