using day5;

namespace Tests
{
    public class Day5ChallegeTests
    {
        private Day5Challenge _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new Day5Challenge();
        }

        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        public void Validate_Returns_TrueIfNice(string input, bool expectedResult)
        {
            // Arrange
            var niceCount = 0;
            // Act
            _sut.Validate(ref niceCount, input);

            // Assert
            //result.Should().Be(expectedResult);

        }

    }
}
