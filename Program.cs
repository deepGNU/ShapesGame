using System.Diagnostics;

class Program
{
    const int MAX_SHAPES = 14;
    const int INITAL_SHAPES = 6;
    const int TOTAL_ROUNDS = MAX_SHAPES - INITAL_SHAPES + 1;
    static Snake snek;
    static RandomShapeList shapes;
    static int maxX = 80;
    static int maxY = 25;

    static void Main(string[] args)
    {
        Console.SetWindowSize(maxX, maxY + 1);
        //Console.SetBufferSize(maxX, maxY + 1);
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int numOfShapes = INITAL_SHAPES; numOfShapes <= MAX_SHAPES; numOfShapes++)
            PlayRound(numOfShapes);

        stopwatch.Stop();
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.ResetColor();
        Console.WriteLine("GAME OVER");
        Console.WriteLine($"YOUR SCORE: {Snake.Score} POINTS");
        Console.WriteLine($"ROUNDS PLAYED: {TOTAL_ROUNDS}");
        Console.WriteLine($"TIME: {stopwatch.Elapsed.TotalSeconds:0.0} SECONDS");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static void PlayRound(int numOfShapes)
    {
        Console.Clear();
        shapes = new RandomShapeList(numOfShapes);
        snek = new Snake(RandomStartPoint());

        while (!shapes.IsHit(snek.Head) && !snek.IsSteppingOnSelf())
        {
            //PrintGameState(numOfShapes);
            Thread.Sleep(50);
            snek.Move();
        }

        snek.Head.Draw('X', ConsoleColor.Red);
        Console.Beep();
        Thread.Sleep(1000);
        while (Console.KeyAvailable)
            Console.ReadKey(true);
    }

    static Point RandomStartPoint()
    {
        Point point;
        do
        {
            point = Point.GetRandom(maxX, maxY, 0, 1);
        } while (shapes.IsHit(point));
        return point;
    }

    static void PrintGameState(int numShapes)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"TOTAL SCORE: {Snake.Score}");
        Console.Write(" | ");
        Console.Write($"ROUND {numShapes - INITAL_SHAPES + 1} OUT OF {MAX_SHAPES - INITAL_SHAPES + 1}");
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
