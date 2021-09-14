using FluentAssertions;
using Moq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Palindrome.Tests
{
	public class ProgramIntegrationTests
	{
        private readonly IPalindromeProcessor _sut;
        private readonly Mock<IPalindrome> _palindromeMock;

        public ProgramIntegrationTests()
        {
            _sut = PalindromeProcessor.Instance;
            _palindromeMock = new Mock<IPalindrome>();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task palindrome_processor_should_return_output(bool result)
        {
            // Arrange
            _palindromeMock.Setup(x => x.IsPalindrome()).ReturnsAsync(result);
			
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);

			// Act
			_sut.ProcessPalindrome(_palindromeMock.Object, writer);

			// Assert
			string output = Encoding.UTF8.GetString(stream.ToArray());
            output.Should().Equals(result.ToString());
		}
    }
}