using System.Diagnostics;

class Program
{
    public static int firstRow = 1;
    const int MAX_SHAPES = 14;
    const int INITAL_SHAPES = 6;
    const int TOTAL_ROUNDS = MAX_SHAPES - INITAL_SHAPES + 1;
    static Snake snek;
    static RandomShapeList shapes;
    static int maxX = 80;
    static int maxY = 25;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.SetWindowPosition(0, 0);
        Console.SetWindowSize(maxX + 2, maxY + 2);
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int numOfShapes = INITAL_SHAPES; numOfShapes <= MAX_SHAPES; numOfShapes++)
            PlayRound(numOfShapes);

        stopwatch.Stop();
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.ResetColor();
        Console.WriteLine("GAME OVER");
        Console.WriteLine($"SCORE: {Snake.Score} POINTS");
        Console.WriteLine($"ROUNDS PLAYED: {TOTAL_ROUNDS}");
        Console.WriteLine($"TIME: {stopwatch.Elapsed.TotalSeconds:0.0} SECONDS");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static void PlayRound(int numOfShapes)
    {
        Console.Clear();
        DrawBorders();

        shapes = new(numOfShapes);
        snek = new(RandomStartPoint());

        while (!shapes.IsHit(snek.Head) && !snek.IsSteppingOnSelf())
        {
            PrintGameState(numOfShapes);
            snek.Move();
        }

        snek.HandleCollision();
    }

    static Point RandomStartPoint()
    {
        Point point;
        do
        {
            point = Point.GetRandom(maxX, maxY, 0, firstRow);
        } while (shapes.IsHit(point));
        return point;
    }

    static void PrintGameState(int numShapes)
    {
        string str = $"TOTAL SCORE: {Snake.Score} | " +
            $"ROUND {numShapes - INITAL_SHAPES + 1} OUT OF {MAX_SHAPES - INITAL_SHAPES + 1}";
        Console.SetCursorPosition(Console.WindowWidth / 2 - str.Length / 2, 0);
        Console.WriteLine(str);
    }

    static void DrawBorders()
    {
        Console.ResetColor();
        Console.SetCursorPosition(1, 0);

        for (int i = 1; i < Console.WindowWidth - 1; i++)
            Console.Write('_');
        Console.WriteLine();

        for (int i = 1; i < Console.WindowHeight - 1; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine('|');
            Console.SetCursorPosition(Console.WindowWidth - 1, i);
            Console.WriteLine('|');
        }

        Console.SetCursorPosition(1, Console.WindowHeight - 1);

        for (int i = 1; i < Console.WindowWidth - 1; i++)
        {
            Console.Write('‾');
        }
    }

    //int GetRemainingArea()
    //{
    //    return GetTotalArea() - GetShapesArea() - snek.Area;
    //}

    //int GetShapesArea()
    //{
    //    return shapes.Aggregate((s1, s2) => s1.Area + s2.Area);
    //}

    //int GetTotalArea()
    //{
    //    return maxX * maxY;
    //}
}
