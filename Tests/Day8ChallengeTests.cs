using day8;
using FluentAssertions;

namespace Tests
{
    public class Day8ChallengeTests
    {
 
        [Test]
        public void TestStringLiteralCount()
        {
            // Arrange
            using var sr = new StreamReader("day8TestInput.txt");
            var input = sr.ReadToEnd();
            var sut = new Day8Challenge();
            var expectedTotalCount = 11;

            // Act
            var count = sut.StringCount(input);

            // Assert
            count.Should().Be(expectedTotalCount);
        }


        [Test]
        public void TestInMemoryCount()
        {
            // Arrange
            var sut = new Day8Challenge();
            using var sr = new StreamReader("day8TestInput.txt");
            var expectedCount = new int[] { 2, 5, 10, 6 };
            var x = 23;
            var input = sr.ReadToEnd();
            // Act
            var count = sut.AllCharacterCount(input);
            // Assert
            count.Should().Be(x);
            


        }
    }
}
