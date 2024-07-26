var inputFilePath = "./input.txt";
int GetFirstNumberFromString(string inputString)
{
    foreach (char character in inputString)
    {
        if (int.TryParse(character.ToString(), out int resultNumber))
        {
            return resultNumber;
        }
    }

    return 0;
}

if (!File.Exists(inputFilePath))
{
    Console.Write("No input file provided! ");
    Console.WriteLine($@"Expected file ""{inputFilePath}"" to be preset in current directory.");
    Environment.Exit(1);
}

int calibrationValuesSum = default;

try
{
    using (StreamReader fileReader = new(inputFilePath))
    {
        string? line;

        while ((line = fileReader.ReadLine()) != null)
        {
            int firstNumber = GetFirstNumberFromString(line);

            string reversedLine = new(line.Reverse().ToArray());
            int lastNumber = GetFirstNumberFromString(reversedLine);

            int resultNumber = (firstNumber * 10) + lastNumber;
            calibrationValuesSum += resultNumber;
        }
    }
}
catch (Exception exception)
{
    Console.WriteLine($"The input file could not be read: {exception.Message}");
    Environment.Exit(1);
}

Console.WriteLine($"Sum of calibration values from given input is: {calibrationValuesSum}");
