
namespace MastermindConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("The computer will create a 4-digit code with numbers between 1 and 6 (inclusive).");
            Console.WriteLine("Your job as the player is to guess the code.");
            Console.WriteLine("A '+' means you got a digit correct and in the correct position.");
            Console.WriteLine("A '-' means you got a digit correct but in the wrong position.");
            Console.WriteLine("You have 10 guesses to crack the code. Good luck!");

            Random rand = new();

            string numberCodeString = "";

            for (int index = 0; index < 4; index++)
            {
                numberCodeString = numberCodeString + rand.Next(1, 7).ToString();
            }

            //  Comment this back in to check if code is working:
            //Console.WriteLine(numberCodeString);

            Console.WriteLine("");

            int turnCounter = 1;

            while (turnCounter < 11 && turnCounter > 0)
            {
                turnCounter = TakeTurn(turnCounter, numberCodeString);
            }

            if (turnCounter == 11)
            {
                Console.WriteLine("You Loose.");
            }
        }

        //  I don't love that there's "side effects" in here like reading and writing to the console,
        //  but I wasn't sure else how to loop the logic ~10times wo a method....
        public static int TakeTurn(int turnCounter, string numberCodeString)
        {
            Console.WriteLine("Enter your Guess" + turnCounter);

            string? guessString = Console.ReadLine();

            bool hasNonValidInput = CheckIfHasNonValidInput(guessString);

            if (hasNonValidInput)
            {
                Console.WriteLine("Please enter four numbers between 1 and 6.");
                return turnCounter;
            }
            else
            {
                string guessResults = HandleGuess(numberCodeString, guessString!);
                Console.WriteLine("Guess Results: " + guessResults);

                if (guessResults == "++++")
                {
                    Console.WriteLine("You Win!");
                    //  Setting it to -1 so it doesn't try to make you take more turns.
                    //  I feel like there might be a better way to handle this,
                    //  but I can't think of anything offhand. Like I wish I could return a win boolean,
                    //  but I'm already returning the turnCounter :(
                    turnCounter = -1;
                }

                Console.WriteLine("");
                return turnCounter + 1;
            }
        }

        public static bool CheckIfHasNonValidInput(string? guessString)
        {
            if (guessString == null || guessString.Length != 4)
            {
                return true;
            }
            else
            {
                for (int index = 0; index < 4; index++)
                {
                    if (!(guessString[index] == '1' || guessString[index] == '2' || guessString[index] == '3' || guessString[index] == '4' || guessString[index] == '5' || guessString[index] == '6'))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static string HandleGuess(string numberCodeString, string guessString)
        {
            string guessResults = "";
            //  We don't want to count the same number more than once,
            //  like a user could enter "3333" and the number could be "1234",
            //  want to make sure the 3 only counts as 1 "+", not three "-" as well or something.
            List<bool> guessStringUsedNumbers = [false, false, false, false];
            List<bool> numberCodeStringUsedNumbers = [false, false, false, false];

            for (int index = 0; index < 4; index++)
            {
                if (guessString![index] == numberCodeString[index])
                {
                    guessResults = guessResults + "+";
                    guessStringUsedNumbers[index] = true;
                    numberCodeStringUsedNumbers[index] = true;
                }
            }

            for (int index = 0; index < 4; index++)
            {
                for (int index2 = 0; index2 < 4; index2++)
                {
                    if (guessString![index] == numberCodeString[index2] && guessStringUsedNumbers[index] == false && numberCodeStringUsedNumbers[index2] == false)
                    {
                        guessResults = guessResults + "-";
                        guessStringUsedNumbers[index] = true;
                        numberCodeStringUsedNumbers[index2] = true;
                        //  Whoops, and need a break to not count numbers more than once as well!
                        break;
                    }
                }
            }

            return guessResults;
        }
    }
}