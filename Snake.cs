class Snake
{
    public Point Head { get { return _headPosition; } }
    private Point _headPosition;
    private Point _prevHeadPosition;
    private List<Point> _path;
    private int _maxX = Console.WindowWidth - 1;
    private int _maxY = Console.WindowHeight - 1;

    public Snake(Point start)
    {
        _headPosition = _prevHeadPosition = start;
        _path = new List<Point>();
        DrawHead();
    }

    public void Move()
    {
        _prevHeadPosition = _headPosition.Clone();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:    MoveUp();    break;
            case ConsoleKey.DownArrow:  MoveDown();  break;
            case ConsoleKey.RightArrow: MoveRight(); break;
            case ConsoleKey.LeftArrow:  MoveLeft();  break;
        }

        if (DidMove())
        {
            _path.Add(_prevHeadPosition);
            DrawHead();
        }
    }

    private bool DidMove()
    {
        return !_headPosition.Equals(_prevHeadPosition);
    }

    private void MoveUp()
    {
        if (_headPosition.Y > 0)
            _headPosition.Y--;
    }

    private void MoveDown()
    {
        if (_headPosition.Y < _maxY)
            _headPosition.Y++;
    }

    private void MoveRight()
    {
        if (_headPosition.X < _maxX)
            _headPosition.X++;
    }

    private void MoveLeft()
    {
        if (_headPosition.X > 0)
            _headPosition.X--;
    }

    private void DrawHead()
    {
        DrawStar(_prevHeadPosition, ConsoleColor.Blue);
        DrawStar(_headPosition, ConsoleColor.White);
    }

    private void DrawStar(Point point, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(point.X, point.Y);
        Console.Write("*");
    }

    public bool IsSteppingOnSelf()
    {
        foreach (var point in _path)
            if (point.Equals(_headPosition)) return true;
        return false;
    }
}