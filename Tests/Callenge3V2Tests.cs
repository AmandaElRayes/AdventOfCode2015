using day3;
using FluentAssertions;

namespace Tests
{
    public class Callenge3V2Tests
    {
        private Challenge3V2 _sut;
        [SetUp]
        public void SetUp()
        {
            _sut = new Challenge3V2();
        }

        [TestCase("", 1)]
        [TestCase(">", 2)]
        [TestCase("^", 2)]
        [TestCase("v", 2)]
        [TestCase("<", 2)]
        [TestCase("^>", 3)]
        [TestCase("^>v", 4)]
        [TestCase("^>v<", 4)]
        [TestCase("^v^v^v^v^v", 2)]
        public void CreateMatrix_ReturnsExpectedNumberOfHouses(string input, int expectedNoOfHouses)
        {
            // Act
            var result = _sut.CreateDictionary(input);

            // Assert
            result.Count.Should().Be(expectedNoOfHouses);
        }

    }
}
