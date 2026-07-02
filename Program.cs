Console.WriteLine("Welcome to Mastermind! " +
    "The computer will create a 4-digit code with numbers between 1 and 6 (inclusive). " +
    "Your job as the player is to guess the code. " +
    "A '+' means you got a digit correct and in the correct position. " +
    "A '-' means you got a digit correct but in the wrong position. " +
    "You have 10 guesses to crack the code. Good luck!");

Random rand = new();

List<char> numberCodeAsChars = [];

for (int index = 0; index < 4; index++)
{
    numberCodeAsChars.Add(char.Parse(rand.Next(1, 7).ToString()));
}

//  Temporary to make sure code is working:
Console.WriteLine("" + numberCodeAsChars[0] + numberCodeAsChars[1] + numberCodeAsChars[2] + numberCodeAsChars[3]);
Console.WriteLine("");
Console.WriteLine("Enter your guess");

string? firstGuessString = Console.ReadLine();

bool hasNonValidInput = CheckIfHasNonValidInput(firstGuessString);

if (hasNonValidInput)
{
    Console.WriteLine("Please enter four numbers between 1 and 6.");
}
else
{
    string guessResults = HandleGuess(firstGuessString!, numberCodeAsChars);
    Console.WriteLine("Guess Results: " + guessResults);
}

static bool CheckIfHasNonValidInput(string? guessString)
{
    if (guessString == null || guessString.Length != 4)
    {
        return true;
    }
    else
    {
        for (int index = 0; index < 4; index++)
        {
            if ((guessString[index] == '1' || guessString[index] == '2' || guessString[index] == '3' || guessString[index] == '4' || guessString[index] == '5' || guessString[index] == '6'))
            {
                return false;
            }
        }

        return true;
    }
}

static string HandleGuess(string guessString, List<char> numberCodeAsChars)
{
    string guessResults = "";
    //  We don't want to count the same number more than once,
    //  like a user could enter "3333" and the number could be "1234",
    //  want to make sure the 3 only counts as 1 "+", not three "-" as well or something.
    List<bool> usedNumbers = [false, false, false, false];

    for (int index = 0; index < 4; index++)
    {
        if (guessString![index] == numberCodeAsChars[index])
        {
            guessResults = guessResults + "+";
            usedNumbers[index] = true;
        }
    }

    for (int index = 0; index < 4; index++)
    {
        for (int index2 = 0; index2 < 4; index2++)
        {
            if (guessString![index] == numberCodeAsChars[index2] && usedNumbers[index2] == false)
            {
                guessResults = guessResults + "-";
                usedNumbers[index2] = true;
                //  Whoops, and need a break to not count numbers more than once as well!
                break;
            }
        }
    }

    return guessResults;
}