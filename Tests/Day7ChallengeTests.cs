using day7;
using FluentAssertions;

namespace Tests
{
    public class Day7ChallengeTests
    {
        private day7Challenge _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new day7Challenge();
        }

        [Test]
        public void TestEqual()
        {
            // Arrange
            var emptyDict = new Dictionary<string, int>();
            var input = new string[] { "123", "->", "x" };
            var expectedResult = new Dictionary<string, int>()
            {
                { "x", 123 }
            };

            // Act
            var (failed, result) = _sut.DecodeElement(input, emptyDict);

            // Assert
            failed.Should().BeEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void TestAND()
        {
            // Arrange
            var emptyDict = new Dictionary<string, int>();
            var input = new string[] { "123", "AND", "456", "->", "d" };
            var expectedResult = new Dictionary<string, int>()
            {
                { "d", 72 }
            };

            // Act
            var (failed, result) = _sut.DecodeElement(input, emptyDict);

            // Assert
            failed.Should().BeEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void TestOR()
        {
            // Arrange
            var emptyDict = new Dictionary<string, int>();
            var input = new string[] { "123", "OR", "456", "->", "d" };
            var expectedResult = new Dictionary<string, int>()
            {
                { "d", 507 }
            };

            // Act
            var (failed, result) = _sut.DecodeElement(input, emptyDict);

            // Assert
            failed.Should().BeEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void TestNOT()
        {
            // Arrange
            var emptyDict = new Dictionary<string, int>();
            var input = new string[] { "NOT", "456", "->", "d" };
            var expectedResult = new Dictionary<string, int>()
            {
                { "d", -457 }
            };

            // Act
            var (failed, result) = _sut.DecodeElement(input, emptyDict);

            // Assert
            failed.Should().BeEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void TestLSHIFT()
        {
            // Arrange
            var emptyDict = new Dictionary<string, int>();
            var input = new string[] {"5", "LSHIFT", "5", "->", "d" };
            var expectedResult = new Dictionary<string, int>()
            {
                { "d", 160 }
            };

            // Act
            var (failed, result) = _sut.DecodeElement(input, emptyDict);

            // Assert
            failed.Should().BeEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }


        [Test]
        public void TestRSHIFT()
        {
            // Arrange
            var emptyDict = new Dictionary<string, int>();
            var input = new string[] { "15", "RSHIFT", "435", "->", "d" };
            var expectedResult = new Dictionary<string, int>()
            {
                { "d", 0 }
            };

            // Act
            var (failed, result) = _sut.DecodeElement(input, emptyDict);

            // Assert
            failed.Should().BeEmpty();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
