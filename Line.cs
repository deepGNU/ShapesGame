class Line : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public int Length { get; set; }
    public ConsoleColor Color { get; set; }
    public int Area { get { return _points.Count(); } }
    public List<Point> _points;
    private Random _random = new Random();
    private int _minLength = 2;
    private int _maxLength = 10;

    public Line(ConsoleColor color, char theChar = '=')
    {
        Color = color;
        TheChar = theChar;
        Length = _random.Next(_minLength, _maxLength + 1);
        Left = _random.Next(Console.WindowWidth - Length);
        Top = _random.Next(1, Console.WindowHeight - 1);
        _points = new List<Point>();

        for (int i = 0; i < Length; i++)
            _points.Add(new Point(Left + i, Top));
    }

    public void Draw()
    {
        foreach (Point point in _points)
            point.Draw(TheChar, Color);
    }

    public bool IsHit(Point p)
    {
        foreach (var point in _points)
            if (point.Equals(p)) return true;
        return false;
    }
}