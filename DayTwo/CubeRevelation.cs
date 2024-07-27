namespace DayTwo;

class CubeRevelation(int red, int green, int blue)
{
    int red { get; } = red;
    int green { get; } = green;
    int blue { get; } = blue;

    public bool IsGamePossible(int red, int green, int blue)
    {
        return this.red <= red && this.green <= green && this.blue <= blue;
    }

    public static CubeRevelation FromString(string source)
    {
        Dictionary<string, int> CubeRevelationParams = source.Split(", ")
            .Select(s => s.Split(" "))
            .ToDictionary(a => a[1], a => int.Parse(a[0]));

        int red, green, blue = 0;

        CubeRevelationParams.TryGetValue("red", out red);
        CubeRevelationParams.TryGetValue("green", out green);
        CubeRevelationParams.TryGetValue("blue", out blue);

        return new CubeRevelation(red, green, blue);
    }
}
