class Snake
{
    public Snake(Point start)
    {
        _headPosition = _prevHeadPosition = start;
        _headPosition.Draw(CHAR, HEAD_COLOR);
    }

    public static int Score = 0;
    public Point Head { get { return _headPosition; } }
    private Point _headPosition, _prevHeadPosition;
    private List<Point> _path = new();
    private const char CHAR = '*';
    private const char CRASH_CHAR = 'X';
    private const ConsoleColor HEAD_COLOR = ConsoleColor.White;
    private const ConsoleColor PATH_COLOR = ConsoleColor.Blue;

    public void Move()
    {
        Thread.Sleep(50);
        _prevHeadPosition = _headPosition.Clone();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow: MoveUp(); break;
            case ConsoleKey.DownArrow: MoveDown(); break;
            case ConsoleKey.RightArrow: MoveRight(); break;
            case ConsoleKey.LeftArrow: MoveLeft(); break;
        }

        if (DidMove()) HandleMove();
    }

    public bool DidMove()
    {
        return !_headPosition.Equals(_prevHeadPosition);
    }

    private void MoveUp()
    {
        if (_headPosition.Y > Board.MinY)
            _headPosition.Y--;
    }

    private void MoveDown()
    {
        if (_headPosition.Y < Board.MaxY)
            _headPosition.Y++;
    }

    private void MoveRight()
    {
        if (_headPosition.X < Board.MaxX)
            _headPosition.X++;
    }

    private void MoveLeft()
    {
        if (_headPosition.X > Board.MinX)
            _headPosition.X--;
    }

    private void DrawMove()
    {
        _prevHeadPosition.Draw(CHAR, PATH_COLOR);
        _headPosition.Draw(CHAR, HEAD_COLOR);
    }

    public bool IsSteppingOnSelf()
    {
        foreach (var point in _path)
            if (_headPosition.Equals(point)) return true;
        return false;
    }

    public void MarkHit()
    {
        foreach (var point in _path)
            point.Draw(CRASH_CHAR, ConsoleColor.White);
    }

    private void HandleMove()
    {
        Score++;
        _path.Add(_prevHeadPosition);
        DrawMove();
        FlushKeyboard();
    }

    public void IndicateCollision()
    {
        Console.Beep();
        FlashCrash();
        FlushKeyboard();
    }

    private void FlashCrash()
    {
        for (int i = 0; i < 5; i++)
        {
            ConsoleColor color = i % 2 == 0 ? ConsoleColor.Red : ConsoleColor.White;
            _headPosition.Draw(CRASH_CHAR, color);
            Thread.Sleep(200);
        }
    }

    private void FlushKeyboard()
    {
        while (Console.KeyAvailable)
            Console.ReadKey(true);
    }
}