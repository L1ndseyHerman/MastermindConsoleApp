
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
            string guessResults = Program.HandleGuess("1234", "1366");

            Assert.Equal("+-", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesMoreThanOneOfTheSameNumberButThereIsOnlyOneInTheCode_OnlyReturnsOneResultForTheNumber()
        {
            string guessResults = Program.HandleGuess("1234", "1111");

            Assert.Equal("+", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesMoreThanOneOfTheSameNumberButThereIsOnlyOneInTheCode_OnlyReturnsOneResultForTheNumberDifGuess()
        {
            string guessResults = Program.HandleGuess("1234", "3333");

            Assert.Equal("+", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesMoreThanOneOfTheSameNumberButThereIsOnlyOneInTheCode_OnlyReturnsOneResultForTheNumberMinusesToo()
        {
            string guessResults = Program.HandleGuess("1234", "6611");

            Assert.Equal("-", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesMoreThanOneOfTheSameNumberButThereIsOnlyOneInTheCode_OnlyReturnsOneResultForTheNumberMinusesTooDifGuess()
        {
            string guessResults = Program.HandleGuess("1234", "3366");

            Assert.Equal("-", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesMoreThanOneOfTheSameNumberButThereIsOnlyOneInTheCode_OnlyReturnsOneResultForTheNumberPlusAndMinus()
        {
            string guessResults = Program.HandleGuess("1234", "1313");

            Assert.Equal("+-", guessResults);
        }

        [Fact]
        public void HandleGuess_WherePlayerGuessesMoreThanOneOfTheSameNumberButThereIsOnlyOneInTheCode_OnlyReturnsOneResultForTheNumberPlusAndMinusDifGuess()
        {
            string guessResults = Program.HandleGuess("1234", "3131");

            Assert.Equal("+-", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasAllTheSameNumber_CanReturnPlusses()
        {
            string guessResults = Program.HandleGuess("1111", "1111");

            Assert.Equal("++++", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasAllTheSameNumber_CanReturnTheEmptyString()
        {
            string guessResults = Program.HandleGuess("1111", "6666");

            Assert.Equal("", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasAllTheSameNumber_CanReturnMix()
        {
            string guessResults = Program.HandleGuess("1111", "1616");

            Assert.Equal("++", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnAllPlusses()
        {
            string guessResults = Program.HandleGuess("1212", "1212");

            Assert.Equal("++++", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnSomePlusses()
        {
            string guessResults = Program.HandleGuess("1212", "1266");

            Assert.Equal("++", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnSomePlussesDifGuess()
        {
            string guessResults = Program.HandleGuess("1212", "6612");

            Assert.Equal("++", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnAllMinuses()
        {
            string guessResults = Program.HandleGuess("1212", "2121");

            Assert.Equal("----", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnSomeMinuses()
        {
            string guessResults = Program.HandleGuess("1212", "2166");

            Assert.Equal("--", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnSomeMinusesDifGuess()
        {
            string guessResults = Program.HandleGuess("1212", "6621");

            Assert.Equal("--", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnTheEmptyString()
        {
            string guessResults = Program.HandleGuess("1212", "6666");

            Assert.Equal("", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnMixOfPlusAndMinus()
        {
            string guessResults = Program.HandleGuess("1212", "1221");

            Assert.Equal("++--", guessResults);
        }

        [Fact]
        public void HandleGuess_WhereCodeHasMultipleSameNumbers_CanReturnMixOfPlusAndMinusDifGuess()
        {
            string guessResults = Program.HandleGuess("1212", "2616");

            Assert.Equal("+-", guessResults);
        }
    }
}
