namespace YogaManagement.Common
{
    public static class Const
    {
        #region REGEX
        public static readonly string PASSWORD_REGEX = @"^(?=.*\d)(?=.*[A-Z])(?=.*[\W_]).+$";
        #endregion

        #region SESSION/COOKIE
        public static readonly string COOKIE_SCHEME = "CookieAuthentication";
        public static readonly string COOKIE_AUTH = "CookieAuthentication";
        public static readonly string SESSION_REGISTER = "RegisterSuccess";
        public static readonly int SESSION_EXPIRED_TIME_MINUTE = 5;
        #endregion

        #region UserRole
        public static readonly string ADMIN_POLICY = "AdminOnly";
        public static readonly string ROLE_ADMIN = "admin";
        public static readonly string ROLE_USER = "user";
        #endregion
    }

    public enum DaysInWeek
    {
        Five,
        Three,
        Mix
    }
}
