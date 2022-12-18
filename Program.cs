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
        Console.SetWindowPosition(0, 0);
        Console.SetWindowSize(maxX, maxY);
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
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
        PrintBorder();
        //Console.SetWindowPosition(0, 0);
        //Console.SetWindowSize(maxX, maxY);
        shapes = new RandomShapeList(numOfShapes);
        snek = new Snake(RandomStartPoint());

        while (!shapes.IsHit(snek.Head) && !snek.IsSteppingOnSelf())
        {
            PrintGameState(numOfShapes);
            snek.Move();
        }

        snek.Head.Draw("X", ConsoleColor.Red);
        Console.Beep();
        Snake.Score--;
        Thread.Sleep(1000);
        while (Console.KeyAvailable)
            Console.ReadKey(true);
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
        PrintBorder();
        string mssg = $"TOTAL SCORE: {Snake.Score} | " +
            $"ROUND {numShapes - INITAL_SHAPES + 1} OUT OF {MAX_SHAPES - INITAL_SHAPES + 1}";
        Console.SetCursorPosition(Console.WindowWidth / 2 - mssg.Length / 2, 0);
        Console.WriteLine(mssg);

        //Console.Write($"TOTAL SCORE: {Snake.Score}");
        //Console.Write(" | ");
        //Console.Write($"ROUND {numShapes - INITAL_SHAPES + 1} OUT OF {MAX_SHAPES - INITAL_SHAPES + 1}");
    }

    static void PrintBorder()
    {
        Console.ResetColor();
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write('_');
        Console.WriteLine();
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
