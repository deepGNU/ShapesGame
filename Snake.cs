class Snake
{
    public static int Score = 0;
    public Point Head { get { return _headPosition; } }
    public int Area { get { return _path.Count() + 1; } }
    private Point _headPosition;
    private Point _prevHeadPosition;
    private List<Point> _path;
    private int _maxX = Console.WindowWidth - 1;
    private int _maxY = Console.WindowHeight - 1;
    private const string _CHAR = "*";
    private const ConsoleColor _HEAD_COLOR = ConsoleColor.White;
    private const ConsoleColor _PATH_COLOR = ConsoleColor.Blue;

    public Snake(Point start)
    {
        _path = new List<Point>();
        _headPosition = _prevHeadPosition = start;
        _headPosition.Draw(_CHAR, _HEAD_COLOR);
    }

    public void Move()
    {
        Thread.Sleep(50);
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
            DrawMove();
            _path.Add(_prevHeadPosition);
            Score++;
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
    }

    private bool DidMove()
    {
        return !_headPosition.Equals(_prevHeadPosition);
    }

    private void MoveUp()
    {
        if (_headPosition.Y > Program.firstRow)
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

    private void DrawMove()
    {
        _prevHeadPosition.Draw(_CHAR, _PATH_COLOR);
        _headPosition.Draw(_CHAR, _HEAD_COLOR);
    }

    public bool IsSteppingOnSelf()
    {
        foreach (Point point in _path)
            if (_headPosition.Equals(point)) return true;
        return false;
    }
}