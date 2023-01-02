static class Board
{
    static Random _random = new();
    public const int MaxX = 80, MaxY = 25, MinX = 1, MinY = 1;

    // Fills board with LTR marks to ensure proper behavior with RTL chars.
    public static void PrintLTRs()
    {
        Console.SetCursorPosition(MinX, MinY);
        for (int y = MinY; y <= MaxY; y++)
        {
            Console.SetCursorPosition(MinX, y);
            for (int x = MinX; x <= MaxX; x++)
                Console.Write("\u200E");
            Console.WriteLine();
        }
    }

    public static void DrawBorders()
    {
        Console.ResetColor();
        Console.SetCursorPosition(MinX, 0);

        for (int x = MinX; x <= MaxX; x++)
            Console.Write('_');
        Console.WriteLine();

        for (int y = MinY; y <= MaxY ; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.WriteLine('|');
            Console.SetCursorPosition(MaxX + 1, y);
            Console.WriteLine('|');
        }

        Console.SetCursorPosition(MinX, MaxY + 1);

        for (int x = MinX; x <= MaxX; x++)
            Console.Write('‾');
    }

    public static Point GetRandomPoint(int maxX = MaxX, int maxY = MaxY)
    {
        int x = _random.Next(MinX, maxX + 1);
        int y = _random.Next(MinY, maxY + 1);
        return new Point(x, y);
    }
}