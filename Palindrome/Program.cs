using System;
using System.IO;

namespace Palindrome
{
	public class Program
	{
		static void Main(string[] args)
		{
			var palindromeProcessor = PalindromeProcessor.Instance;
			TextWriter textWriter = Console.Out;
			textWriter.WriteLine("Enter a string of any length: ");
			string str = Console.ReadLine().Trim();
			IPalindrome palindrome = new Palindrome(str);

			palindromeProcessor.ProcessPalindrome(palindrome, textWriter);
		}
	}
}