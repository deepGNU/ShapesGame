using System.Diagnostics;

class Program
{
    static int maxShapes = 14;
    static int minShapes = new Random().Next(3,7);
    static int consoleWidth = Board.MaxX + 2;
    static int consoleHeight = Board.MaxY + 2;
    static int numFails = 0;
    static int numShapes;
    static Stopwatch stopwatch;
    static RandomShapeList shapes;
    static Point startPoint;
    static Snake snek;

    static void Main(string[] args)
    {
        SetConsoleSettings();
        stopwatch = Stopwatch.StartNew();
        for (numShapes = minShapes; numShapes <= maxShapes; numShapes++)
            PlayRound();
        stopwatch.Stop();
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
        if (!SetStartPointInMaxTries()) return;
        snek = new(startPoint);

        while (!shapes.IsHit(snek.Head) && !snek.IsSteppingOnSelf())
        {
            PrintGameState();
            snek.Move();
        }

        HandleCollision();
    }

    static bool SetStartPointInMaxTries()
    {
        int maxStartPointTries = 30;
        int count = 0;
        do startPoint = Board.GetRandomPoint();
        while (shapes.IsHit(startPoint) && ++count <= maxStartPointTries);
        return count <= maxStartPointTries;
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
