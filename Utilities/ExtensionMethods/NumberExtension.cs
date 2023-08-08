namespace Utilities.ExtensionMethods
{
    public static class NumberExtension
    {
        public static string ToString00(this int number)
        {
            return number.ToString("00");
        }

        public static string ToString(this short number)
        {
            return number.ToString("00");
        }
    }
}
