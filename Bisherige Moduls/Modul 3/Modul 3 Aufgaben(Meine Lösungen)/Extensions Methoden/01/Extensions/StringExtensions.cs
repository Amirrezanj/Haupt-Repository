namespace _01.Extensions
{
    public static class StringExtensions
    {
        public static bool IsPalindrom(this string str)
        {
            str = str.ToLower();
                    int left = 0;
                    int right = str.Length - 1;

                    while (left < right)
                    {
                        if (str[left] != str[right])
                        {
                            return false;
                        }
                        left++;
                        right--;
                    }

                    return true;
        }
        public static string Umgekehrt(this string str)
        {

            string result = null; 
            for (int i = str.Length - 1; i >= 0; i--) 
            {
                result += str[i];
            }
            return result!;
        }
        public static List<T> Listen<T>(this T [] arr )
        {
            return new List<T>(arr);
        }
    }
}