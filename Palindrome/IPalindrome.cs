using System.Threading.Tasks;

namespace Palindrome
{
	public interface IPalindrome
	{
		Task<bool> IsPalindrome();
	}
}