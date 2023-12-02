using day4;
using FluentAssertions;

namespace Tests
{
    public class Day4ChallengeTests
    {
        private Day4Challenge _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new Day4Challenge();
        }

        [TestCase("abcdef609043")]
        [TestCase("pqrstuv1048970")]
        public void String_ReturnsMD5HashWith5LeadingZeroes(string input)
        {
            // Arrange

            // Act
            var hash = _sut.CreateMD5(input);

            // Assert

            hash.StartsWith("00000").Should().BeTrue();
        }

        [TestCase("abcdef", 609043)]
        [TestCase("pqrstuv", 1048970)]
        public void SecretKey_ReturnsLowestNumberInCombination(string secretKey, int answer)
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
