static class RandomColor
{
    private static Random _random = new();

    public static ConsoleColor Get()
    {
        Array colors = ((IEnumerable<ConsoleColor>)
            Enum.GetValues(typeof(ConsoleColor)))
            .Where(x => x != ConsoleColor.Black).ToArray();

        return (ConsoleColor)colors.GetValue(_random.Next(colors.Length));
    }

}