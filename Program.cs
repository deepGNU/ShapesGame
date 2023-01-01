using System.Diagnostics;

class Program
{
    const int MAX_SHAPES = 14, MIN_SHAPES = 6;
    const int MAX_ROUNDS = MAX_SHAPES - MIN_SHAPES + 1;
    static int numShapes;
    static Snake snek;
    static RandomShapeList shapes;
    static int maxX = 80;
    static int maxY = 25;
    static List<Point> pointsOnBoard = Enumerable.Range(1, maxX)
            .Select(x => 
                Enumerable.Range(1, maxY)
                .Select(y => new Point(x, y)))
            .SelectMany(e => e)
            .ToList();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.SetWindowPosition(0, 0);
        Console.SetWindowSize(maxX + 2, maxY + 2);
        Console.SetBufferSize(maxX + 2, maxY + 2);
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (numShapes = MIN_SHAPES; numShapes <= MAX_SHAPES; numShapes++)
            PlayRound();

        stopwatch.Stop();
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.ResetColor();
        Console.WriteLine("GAME OVER");
        Console.WriteLine($"SCORE: {Snake.Score} POINTS");
        Console.WriteLine($"ROUNDS PLAYED: {MAX_ROUNDS}");
        Console.WriteLine($"TIME: {stopwatch.Elapsed.TotalSeconds:0.0} SECONDS");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static void PlayRound()
    {
        Console.Clear();
        PrintLTRs(); // Filling screen with LTR marks to avoid problems with Hebrew letter 'ם'.
        DrawBorders();

        shapes = new(numShapes);
        snek = new(RandomStartPoint());

        while (!shapes.IsHit(snek.Head) && !snek.IsSteppingOnSelf())
        {
            PrintGameState();
            snek.Move();
        }

        if (snek.IsSteppingOnSelf())
            snek.MarkHit();
        else
            shapes.MarkHit(snek.Head);

        snek.HandleCollision();
    }

    static Point RandomStartPoint()
    {
        //return kosherPoints[new Random().Next(kosherPoints.Count())];
        Point point;
        do
        {
            point = Point.GetRandom(maxX, maxY, 1, 1);
        } while (shapes.IsHit(point));
        return point;
    }

    static void PrintGameState()
    {
        string str = $"ROUND {GetCurrRound()} OUT OF {MAX_ROUNDS}"
            + $" | TOTAL SCORE: {Snake.Score}";
        Console.SetCursorPosition((Console.WindowWidth / 2) - (str.Length / 2) - 1, 0);
        Console.WriteLine(str);
    }

    static int GetCurrRound()
    {
        return numShapes - MIN_SHAPES + 1;
    }

    static void PrintLTRs()
    {
        Console.SetCursorPosition(0, 0);
        for (int j = 0; j < Console.WindowHeight; j++)
        {
            Console.SetCursorPosition(0, j);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("\u200E");
            }
            Console.WriteLine();
        }
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
