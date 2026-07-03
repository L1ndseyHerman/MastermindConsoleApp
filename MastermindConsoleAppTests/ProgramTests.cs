
using MastermindConsoleApp;

namespace MastermindConsoleAppTests
{
    public class ProgramTests
    {
        [Fact]
        public void CheckIfHasNonValidInput_WithNonValidInput_ReturnsTrue()
        {
            bool result = Program.CheckIfHasNonValidInput("a");

            Assert.True(result);
        }
    }
}
