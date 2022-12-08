class Snake
{
    private Point _headPosition;
    public Point Head { get { return _headPosition; } }
    private List<Point> _points;
    private int _maxX = Console.WindowWidth - 1;
    private int _maxY = Console.WindowHeight - 1;
    public Snake(Point start)
    {
        _headPosition = start;
        _points = new List<Point>();
        _points.Add(_headPosition.Clone());
        Console.ForegroundColor = ConsoleColor.White;
        DrawHead();
    }

    public bool Move()
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        // Console.ForegroundColor = ConsoleColor.Blue;
        // DrawHead();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (_headPosition.Y == 0) return true;
                _headPosition.Y--;
                break;
            case ConsoleKey.DownArrow:
                if (_headPosition.Y == _maxY) return true;
                _headPosition.Y++;
                break;
            case ConsoleKey.RightArrow:
                if (_headPosition.X == _maxX) return true;
                _headPosition.X++;
                break;
            case ConsoleKey.LeftArrow:
                if (_headPosition.X == 0) return true;
                _headPosition.X--;
                break;
            default:
                return true;
        }

        if (SteppingOnSnek(_headPosition)) return false;
        _points.Add(_headPosition.Clone());
        Console.ForegroundColor = ConsoleColor.White;
        DrawHead();
        return true;
    }

    public void MoveUp()
    {
        if (_headPosition.Y > 0)
        {
            _headPosition.Y--;
            DrawHead();
        }
    }

    public void MoveDown()
    {
        if (_headPosition.Y < _maxY)
        {
            _headPosition.Y++;
            DrawHead();
        }
    }

    public void MoveRight()
    {
        if (_headPosition.X < _maxX)
        {
            _headPosition.X++;
            DrawHead();
        }
    }

    public void MoveLeft()
    {
        if (_headPosition.X > 0)
        {
            _headPosition.X--;
            DrawHead();
        }
    }

    private void DrawHead()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(_headPosition.X, _headPosition.Y);
        Console.Write("*");
    }

    public bool SteppingOnSnek(Point p)
    {
        foreach (var point in _points)
            if (point.Equals(p)) return true;
        return false;
    }
}