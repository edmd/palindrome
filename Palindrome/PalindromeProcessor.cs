using System.IO;

namespace Palindrome
{
    public sealed class PalindromeProcessor : IPalindromeProcessor
    {
        private static readonly PalindromeProcessor instance = new();

        static PalindromeProcessor()
        {
        }

        private PalindromeProcessor()
        {
        }

        public static PalindromeProcessor Instance
        {
            get
            {
                return instance;
            }
        }

        public async void ProcessPalindrome(IPalindrome palindrome, TextWriter textWriter)
        {
            var result = await palindrome.IsPalindrome();
            textWriter.WriteLine(result.ToString());

            textWriter.Flush();
            textWriter.Close();
        }
    }
}