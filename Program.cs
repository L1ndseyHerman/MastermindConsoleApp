Console.WriteLine("Placeholder");

Random rand = new();

List<char> numberCodeAsChars = [];

for (int index = 0; index < 4; index++)
{
    numberCodeAsChars.Add(char.Parse(rand.Next(1, 7).ToString()));
}

Console.WriteLine("" + numberCodeAsChars[0] + numberCodeAsChars[1] + numberCodeAsChars[2] + numberCodeAsChars[3]);

string? firstGuessString = Console.ReadLine();

string errorMessage = "Please enter four numbers between 1 and 6.";

if (firstGuessString == null || firstGuessString.Length != 4)
{
    Console.WriteLine(errorMessage);
}
else
{
    bool hasNonValidInput = false;

    for (int index = 0; index < 4; index++)
    {
        if (!(firstGuessString[index] == '1' || firstGuessString[index] == '2' || firstGuessString[index] == '3' || firstGuessString[index] == '4' || firstGuessString[index] == '5' || firstGuessString[index] == '6'))
        {
            hasNonValidInput = true;
        }
    }

    if (hasNonValidInput)
    {
        Console.WriteLine(errorMessage);
    }
    else
    {
        string guessResults = "";
        //  We don't want to count the same number more than once,
        //  like a user could enter "3333" and the number could be "1234",
        //  want to make sure the 3 only gets used once instead of 4 times.
        List<bool> usedNumbers = [false, false, false, false];

        for (int index = 0; index < 4; index++)
        {
            if (firstGuessString[index] == numberCodeAsChars[index])
            {
                guessResults = guessResults + "+";
                usedNumbers[index] = true;
            }
        }

        for (int index = 0; index < 4; index++)
        {
            for (int index2 = 0; index2 < 4; index2++)
            {
                if (firstGuessString[index] == numberCodeAsChars[index2] && usedNumbers[index2] == false)
                {
                    guessResults = guessResults + "-";
                    usedNumbers[index2] = true;
                }
            }
        }

        Console.WriteLine("Guess Results: " + guessResults);
    }

}
