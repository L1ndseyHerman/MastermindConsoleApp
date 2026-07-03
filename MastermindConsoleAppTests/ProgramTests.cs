
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

        [Fact]
        public void HandleGuess_WherePlayerGuessesTheCode_ReturnsAllPlusses()
        {
            string guessResults = Program.HandleGuess("1234", "1234");

            Assert.Equal("++++", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesSomeNumbersInTheCorrectSpots_ReturnsSomePlusses()
        {
            string guessResults = Program.HandleGuess("1234", "1636");

            Assert.Equal("++", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesAllTheRightNumbersButAllInTheWrongSpots_ReturnsAllMinuses()
        {
            string guessResults = Program.HandleGuess("1234", "4321");

            Assert.Equal("----", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesSomeNumbersThatAreRightButInTheWrongSpotAndSomeThatAreJustWrong_ReturnsSomeMinuses()
        {
            string guessResults = Program.HandleGuess("1234", "4626");

            Assert.Equal("--", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesAllTheWrongNumbers_ReturnsTheEmptyString()
        {
            string guessResults = Program.HandleGuess("1234", "6666");

            Assert.Equal("", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesSomeNumbersInTheRightSpotAndSomeInTheWrongSpot_ReturnsAMixOfPlussesAndMinusesWithAllThePlussesFirst()
        {
            string guessResults = Program.HandleGuess("1234", "1324");

            Assert.Equal("++--", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesAMixOfRightSpotWrongSpotAndWrongNumbers_ReturnsTheMix()
        {
            string guessResults = Program.HandleGuess("1234", "1356");

            Assert.Equal("+-", guessResults);
        }
    }
}
