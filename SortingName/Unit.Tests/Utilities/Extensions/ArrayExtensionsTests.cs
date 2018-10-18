using Utilities.Extensions;
using Xunit;

namespace Unit.Tests.Utilities.Extensions
{
    public class ArrayExtensionsTests
    {
        [Theory]
        [InlineData(new[]{1, 2, 3, 4, 5, 6, 7}, 0, 1, new[]{1})]
        [InlineData(new[]{1, 2, 3, 4, 5, 6, 7}, 0, 2, new[]{1, 2})]
        [InlineData(new[]{1, 2, 3, 4, 5, 6, 7}, 2, 5, new[]{3, 4, 5})]
        [InlineData(new[]{1, 2, 3, 4, 5, 6, 7}, 2, -3, new[]{3, 4})]
        public void Slice_SimpleTest(int[] source, int start, int end, int[] expected)
        {
            // Arrange

            // Act
            var actual = source.Slice(start, end);

            // Assert
            Assert.Equal(actual, expected);
        }
    }
}
