using Utilities.Extensions;
using Xunit;

namespace Unit.Tests.Utilities.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("ABC", 3, "ABCABCABCABC")]
        [InlineData("ZXC", 1, "ZXCZXC")]
        [InlineData("ASD", 0, "ASD")]
        [InlineData("QWE", -1, "QWE")]
        public void Repeat_SimpleTest(string originalText, int repeatCount, string expected)
        {
            // Arrange

            // Act
            var actual = originalText.Repeat(repeatCount);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
