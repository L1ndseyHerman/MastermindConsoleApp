Console.WriteLine("Placeholder");

Random rand = new();

List<string> numberCodeAsStrings = [];

for (int i = 0; i < 4; i++)
{
    numberCodeAsStrings.Add(rand.Next(1, 7).ToString());
}

Console.WriteLine(numberCodeAsStrings[0] + numberCodeAsStrings[1] + numberCodeAsStrings[2] + numberCodeAsStrings[3]);

string? guess1 = Console.ReadLine();

// Placeholder for if the user types something other than 1-6:
if (guess1 != "a")
{
    Console.WriteLine("Some error message");
}
else
{
    Console.WriteLine("Placeholder 2");
}
