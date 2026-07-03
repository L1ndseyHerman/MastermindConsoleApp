
using MastermindConsoleApp;

namespace MastermindConsoleAppTests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("12345")]
        [InlineData("abcd")]
        [InlineData("?!*/")]
        [InlineData("7890")]
        [InlineData("123a")]
        [InlineData("7123")]
        public void CheckIfHasNonValidInput_WithNonValidInput_ReturnsTrue(string guessString)
        {
            bool result = Program.CheckIfHasNonValidInput(guessString);

            Assert.True(result);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("6543")]
        [InlineData("1212")]
        [InlineData("1111")]
        public void CheckIfHasNonValidInput_WithValidInput_ReturnsFalse(string guessString)
        {
            bool result = Program.CheckIfHasNonValidInput(guessString);

            Assert.False(result);
        }
    }
}
