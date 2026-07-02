Console.WriteLine("Placeholder");

Random rand = new();

List<string> numberCodeAsStrings = [];

for (int index = 0; index < 4; index++)
{
    numberCodeAsStrings.Add(rand.Next(1, 7).ToString());
}

Console.WriteLine(numberCodeAsStrings[0] + numberCodeAsStrings[1] + numberCodeAsStrings[2] + numberCodeAsStrings[3]);

string? firstGuessString = Console.ReadLine();

if (firstGuessString == null || firstGuessString.Length != 4)
{
    Console.WriteLine("Some error message");
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
        Console.WriteLine("Some error message");
    }
    else
    {
        Console.WriteLine("Placeholder 2");
    }

}
