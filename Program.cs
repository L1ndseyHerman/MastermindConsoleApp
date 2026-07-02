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

        for (int index = 0; index < 4; index++)
        {
            if (firstGuessString[index] == numberCodeAsChars[index])
            {
                guessResults = guessResults + "+";
            }
        }

        Console.WriteLine("Guess Results: " + guessResults);
    }

}
