using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YogaManagement.ViewModel
{
    public static class ModelStateExtension
    {
        public static void GetErrorMessages(this ModelStateDictionary modelState, BaseViewModel model)
        {
            foreach(var key in modelState.Keys)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    if (modelState[key].Errors.Count > 0)
                    {
                        model.Errors.Add(new ErrorViewModel() { 
                            Key = key,
                            Messages = modelState[key].Errors.Select(error => error.ErrorMessage).ToList()
                        });
                    }
                }
            }
        }
    }
}