﻿using day6;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var brightness = 0;

            // Act
            var result = _sut.LightGrid(grid, input, brightness);
            var count = _sut.CountGrid(result.Item1, gridSize);
            Console.WriteLine(result.Item2);
            // Assert
            count.Should().Be(noOfLights);

        }

        [TestCase("turn on 0,0 through 0,0", 1, 1)]
        [TestCase("toggle 0,0 through 999,999", 2000000, 1000)]
        public void TestBrightness(string input, int brightness, int gridSize)
        {
            // Arrange
            var grid = _sut.CreateGrid(gridSize);

            // Act
            var result = _sut.LightGrid(grid, input, 0);
            Console.WriteLine(result.Item2);
            // Assert
            result.Item2.Should().Be(brightness);

        }
    }
}