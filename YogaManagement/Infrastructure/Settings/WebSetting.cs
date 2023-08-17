namespace YogaManagement.Infrastructure.Settings
{
    public class WebSetting
    {
        public string CookieAuthScheme { get; set; } = string.Empty;
        public string CookieAuth { get; set; } = string.Empty;
        public int ExpiredTimeMinutes { get; set; } = 0;
        public string LoginPath { get; set; } = string.Empty;
        public string LogoutPath { get; set; } = string.Empty;
        public string DeniedPath { get; set; } = string.Empty;
    }
}
