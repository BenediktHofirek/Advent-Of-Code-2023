using DayTwo;

var redCubeCount = 12;
var greenCubeCount = 13;
var blueCubeCount = 14;

var inputFilePath = "./input.txt";

var sumOfPossibleGames = 0;

try
{
    using (StreamReader fileReader = new(inputFilePath))
    {
        string line;
        while (fileReader.EndOfStream == false)
        {
            line = fileReader.ReadLine()!;
            var (gameNumber, cubeRevelationList) = parseLine(line);

            if (cubeRevelationList.All(cr => cr.IsGamePossible(redCubeCount, greenCubeCount, blueCubeCount)))
            {
                sumOfPossibleGames += gameNumber;
            }
        };
    }

    Console.WriteLine($"Sum of possible games is {sumOfPossibleGames}");
}
catch (Exception e)
{
    Console.WriteLine($"Unable to open input file: {e.Message}");
    Environment.Exit(1);
}

(int, List<CubeRevelation>) parseLine(string line)
{
    int gameNumber = parseGameNumber(line);

    List<CubeRevelation> cubeRevelationList = parseCubeRevelations(line);

    return (gameNumber, cubeRevelationList);
}

int parseGameNumber(string line)
{
    int indexOfColon = line.IndexOf(':');
    int indexOfSpace = line.IndexOf(' ');

    string gameNumberString = line.Substring(indexOfSpace, indexOfColon - indexOfSpace);
    int gameNumber = int.Parse(gameNumberString);

    return gameNumber;
}

List<CubeRevelation> parseCubeRevelations(string line)
{
    string revelationString = line.Substring(line.IndexOf(':') + 2);
    List<CubeRevelation> cubeRevelationList = revelationString.Split("; ")
        .Select(s => CubeRevelation.FromString(s)).ToList();

    return cubeRevelationList;
}
