namespace YogaManagement.ViewModel.Auth
{
    public class UserViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginViewModel : UserViewModel
    {
        public bool RememberMe { get; set; } = false;
    }

    public class RegisterViewModel : UserViewModel
    {
        public string ConfirmPassword { get; set; }
    }
}
