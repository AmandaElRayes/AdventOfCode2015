using dayz11;
using FluentAssertions;

namespace Tests
{
    public class Dayz11Challenge
    {
        private Day11 _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new Day11();
        }

        [TestCase("abcdffaa", true)]
        [TestCase("ghjaabcc", true)]
        [TestCase("hijklmmn", true)]
        [TestCase("abbceffg", false)]
        [TestCase("abbcegjk", false)]
        [TestCase("abbceabc", true)]
        public void Req1(string input, bool expected)
        {
            // Act
            var success = _sut.CheckReq1(input);
            // Assert
            success.Should().Be(expected);
        }

        [TestCase("abcdffaa", true)]
        [TestCase("ghjaabcc", true)]
        [TestCase("abbceffg", true)]
        [TestCase("hijklmmn", false)]
        [TestCase("abbcegjk", true)]
        public void Req2(string input, bool expected)
        {
            var success = _sut.CheckReq2(input);
            success.Should().Be(expected);

        }

        [TestCase("abcdffaa", true)]
        [TestCase("ghjaabcc", true)]
        [TestCase("abbceffg", true)]
        [TestCase("hijklmmn", false)]
        [TestCase("abbcegjk", false)]
        public void Req3(string input, bool expected)
        {
            var success = _sut.CheckReq3(input);
            success.Should().Be(expected);
        }

        [TestCase("abcdefgh", "abcdffaa")]
        [TestCase("ghijklmn", "ghjaabcc")]
        public void NextPw(string input, string expectedPw)
        {
            var result = _sut.FirstCheck(input);

            result.Should().Be(expectedPw);
        }
    }
}
