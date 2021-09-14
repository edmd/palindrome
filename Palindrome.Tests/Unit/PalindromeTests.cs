using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Palindrome.Tests
{
	public class PalindromeTests
	{
        [Theory]
        [InlineData(1564156, false)]
        [InlineData(233, false)]
        [InlineData(6, false)]
        [InlineData(2, false)]
        [InlineData(0, false)]
        public async Task random_palindromes_should_fail(int size, bool result)
        {
            // Arrange
            var str = Helper.StringGenerator(size);
            IPalindrome palindrome = new Palindrome(str);

            // Act
            var isPalindrome = await palindrome.IsPalindrome();

            // Assert
            isPalindrome.Should().Equals(result);
		}

        [Theory]
        [InlineData("a", true)]
        [InlineData("aA", true)]
        [InlineData("a A", true)]
        [InlineData("aAAa", true)]
        [InlineData("aA Aa", true)]
        [InlineData("aba", true)]
        [InlineData("ab a", true)]
        [InlineData("aabb", true)]
        [InlineData("aabbcc", true)]
        public async Task valid_palindromes_should_return_true(string palindromeStr, bool result)
        {
            // Arrange
            IPalindrome palindrome = new Palindrome(palindromeStr);

            // Act
            var isPalindrome = await palindrome.IsPalindrome();

            // Assert
            isPalindrome.Should().Equals(result);
        }
    }
}