using day6;
using FluentAssertions;

namespace Tests
{
    public class Day6ChallengeTests
    {
        private Day6Challenge _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new Day6Challenge();
        }

        [TestCase("turn on 0,0 through 999,999", 1000000, 1000)]
        [TestCase("turn off 0,0 through 999,999", 0, 1000)]
        [TestCase("toggle 0,0 through 999,0", 1000, 1000)]
        [TestCase("turn off 499,499 through 500,500", 0, 1000)]
        [TestCase("turn on 499,499 through 500,500", 4, 1000)]
        [TestCase("toggle 499,499 through 500,500", 4, 1000)]

        public void Test(string input, int noOfLights, int gridSize)
        {
            // Arrange
            var grid = _sut.CreateGrid(gridSize);
            var brightnessGrid = _sut.CreateGrid(gridSize);

            // Act
            var result = _sut.LightGrid(grid, input, brightnessGrid);
            var count = _sut.CountGrid(result.Item1, gridSize);
            Console.WriteLine(result.Item2);
            // Assert
            count.Should().Be(noOfLights);

        }

        [TestCase("turn on 0,0 through 0,0", 1, 1)]
        [TestCase("toggle 0,0 through 999,999", 2000000, 1000)]
        [TestCase("turn off 1,1 through 100,100", 0, 1000)]
        public void TestBrightness(string input, int brightness, int gridSize)
        {
            // Arrange
            var grid = _sut.CreateGrid(gridSize);
            var brightnessGrid = _sut.CreateGrid(gridSize);

            // Act
            var result = _sut.LightGrid(grid, input, brightnessGrid);
            var brightnessCount = _sut.CountBrightness(result.Item2, gridSize);
            // Assert
            brightnessCount.Should().Be(brightness);

        }
    }
}
