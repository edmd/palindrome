using System.IO;

namespace Palindrome
{
	public interface IPalindromeProcessor
	{
		void ProcessPalindrome(IPalindrome palindrome, TextWriter textWriter);
	}
}