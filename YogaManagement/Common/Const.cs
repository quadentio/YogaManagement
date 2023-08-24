namespace YogaManagement.Common
{
    public static class Const
    {
        public static readonly string COOKIE_SCHEME = "CookieAuthentication";
        public static readonly string COOKIE_AUTH = "CookieAuthentication";
        public static readonly string ADMIN_POLICY = "AdminOnly";

        #region REGEX
        public static readonly string PASSWORD_REGEX = @"^(?=.*\d)(?=.*[A-Z])(?=.*[\W_]).+$";
        #endregion

        #region SESSION
        public static readonly string SESSION_REGISTER = "RegisterSuccess";
        #endregion
    }
}
