using System.Diagnostics;

class Program
{
    static int maxShapes = 14;
    static int minShapes = new Random().Next(3,7);
    static int consoleWidth = Board.MaxX + 2;
    static int consoleHeight = Board.MaxY + 2;
    static int numFails = 0;
    static int numShapes;
    static Stopwatch stopwatch = new();
    static RandomShapeList shapes;
    static Snake snek;
    static Point startPoint;
    static bool foundStartPoint = true;

    static void Main(string[] args)
    {
        SetConsoleSettings();
        // Playing rounds until fail while 14 shapes are on screen,
        // or (extremely unlikely) until failure to place ball within
        // max allowed tries (30 tries) after at least 1 fail.
        for (numShapes = minShapes;
             numShapes <= maxShapes && foundStartPoint;
             numShapes++)
            PlayRound();
        DisplayEndingMessage();
    }

    static void SetConsoleSettings()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.SetWindowPosition(0, 0);
        Console.SetWindowSize(consoleWidth, consoleHeight);
        Console.SetBufferSize(consoleWidth, consoleHeight);
    }

    static void PlayRound()
    {
        Console.Clear();
        Board.DrawBorders();
        Board.PrintLTRs(); // Filling board with LTR marks to avoid problems with Hebrew letter 'ם'.

        shapes = new(numShapes);
        SetStartPointInMaxTries();
        // If start point not found within max allowed tries, ending round.
        if (!foundStartPoint) return;
        snek = new(startPoint);

        stopwatch.Start();
        while (!shapes.IsHit(snek.Head) && !snek.IsSteppingOnSelf())
        {
            PrintGameState();
            snek.Move();
        }
        stopwatch.Stop();

        HandleCollision();
    }

    // Tries to set start point to available point within max tries.
    static void SetStartPointInMaxTries()
    {
        // If there have been no fails (i.e., this is round 1),
        // then max tries is unlimited; otherwise, max tries is 30;
        var maxTries = numFails == 0 ? Double.PositiveInfinity : 30;
        int tries = 0;
        do startPoint = Board.GetRandomPoint();
        while (shapes.IsHit(startPoint) && ++tries <= maxTries);
        foundStartPoint = tries <= maxTries;
    }

    static void PrintGameState()
    {
        string str = $"FAILS: {numFails} | TOTAL SCORE: {Snake.Score}";
        int midWayX = (Console.WindowWidth - str.Length) / 2;
        Console.SetCursorPosition(midWayX, 0);
        Console.WriteLine(str);
    }

    static void HandleCollision()
    {
        Snake.Score--;
        numFails++;
        PrintGameState();
        if (snek.IsSteppingOnSelf()) snek.MarkHit();
        else shapes.MarkHit(snek.Head);
        snek.IndicateCollision();
    }

    static void DisplayEndingMessage()
    {
        double minutes = stopwatch.Elapsed.Minutes;
        double seconds = stopwatch.Elapsed.Seconds;
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.ResetColor();
        Console.WriteLine("GAME OVER");
        Console.WriteLine($"SCORE: {Snake.Score}");
        Console.WriteLine($"FAILS: {numFails}");
        Console.WriteLine("TIME: {0:00}:{1:00}", minutes, seconds);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }
}
