using day8;
using FluentAssertions;

namespace Tests
{
    public class Day8ChallengeTests
    {
        private Day8Challenge _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new Day8Challenge();
        }

        [Test]
        public void TestStringLiteralCount()
        {
            // Arrange
            using var sr = new StreamReader("day8TestInput.txt");
            //var input = sr.ReadToEnd();
            //input = "\"\"\r\n\"abc\"\r\n\"aaa\\\"aaa\"\r\n\"\\x27\"";

            var expectedTotalCount = 11;

            //Act
           var count = _sut.StringCount(sr);

            //Assert
            count.Should().Be(expectedTotalCount);
        }

        [Test]
        public void TestInMemoryCount()
        {
            // Arrange
            using var sr = new StreamReader("day8TestInput.txt");
            var expectedCount = new int[] { 2, 5, 10, 6 };
            var x = 23;
            // Act
            var count = _sut.AllCharacterCount(sr);
            // Assert
            count.Should().Be(x);     
        }
    }
}
