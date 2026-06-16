namespace WebShop.Infrastructure
{
    public static class UtilitiesExtensions
    {

        public static bool IsValid(this string value)
        {
            char[] invalidChars = { '<', '>', '&', '%', ';', '=', '{', '}', '(', ')' };

            if (value == null)
            {
                return false;
            }

            foreach (char c in invalidChars)
            {
                if (value.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
    
}
