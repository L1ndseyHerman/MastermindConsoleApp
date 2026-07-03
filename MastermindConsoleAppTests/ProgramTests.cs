
using MastermindConsoleApp;

namespace MastermindConsoleAppTests
{
    public class ProgramTests
    {
        //  I don't see a reason to test the main method, because all that's in there is console output,
        //  the random number, which we don't want random numbers in tests, we want the same test each time,
        //  and then other basic things like looping logic. I wrote tests for the other 3 methods tho :)

        [Fact]
        public void TakeTurn_WithGuessThatIsNotAWinLooseOrError_IncrementsTheTurnCounter()
        {
            // Mock for Console.WriteLine():
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Mock for Console.ReadLine():
            var inputData = "6666" + Environment.NewLine;
            using var stringReader = new StringReader(inputData);
            Console.SetIn(stringReader);

            int turnCounter = Program.TakeTurn("1234", 1);

            Assert.Equal(2, turnCounter);
        }

        [Fact]
        public void TakeTurn_WithGuessThatIsNotAWinLooseOrError_IncrementsTheTurnCounterDifNumber()
        {
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var inputData = "6666" + Environment.NewLine;
            using var stringReader = new StringReader(inputData);
            Console.SetIn(stringReader);

            int turnCounter = Program.TakeTurn("1234", 5);

            Assert.Equal(6, turnCounter);
        }

        //  It would be nice to test that the "Please enter four numbers between 1 and 6." error message appears,
        //  but I'm not sure how to set up the code in a way that it's testable....
        [Fact]
        public void TakeTurn_WithInvalidCharactersInGuess_DoesNotIncrementTheTurnCounter()
        {
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var inputData = "abcd" + Environment.NewLine;
            using var stringReader = new StringReader(inputData);
            Console.SetIn(stringReader);

            int turnCounter = Program.TakeTurn("1234", 5);

            Assert.Equal(5, turnCounter);
        }

        //  It would be nice to test that the "You Win!" message appears,
        //  but I'm not sure how to set up the code in a way that it's testable....
        [Fact]
        public void TakeTurn_WithGuessThatIsAWin_ReturnsATurnCounterOf0()
        {
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var inputData = "1234" + Environment.NewLine;
            using var stringReader = new StringReader(inputData);
            Console.SetIn(stringReader);

            int turnCounter = Program.TakeTurn("1234", 5);

            Assert.Equal(0, turnCounter);
        }

        //  It would be nice to test that the "You Loose." message appears,
        //  but I'm not sure how to set up the code in a way that it's testable....
        [Fact]
        public void TakeTurn_WithTenthGuessThatStillIsntRight_ReturnsATurnCounterOf11()
        {
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var inputData = "6666" + Environment.NewLine;
            using var stringReader = new StringReader(inputData);
            Console.SetIn(stringReader);

            int turnCounter = Program.TakeTurn("1234", 10);

            Assert.Equal(11, turnCounter);
        }

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
