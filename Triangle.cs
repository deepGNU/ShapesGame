class Triangle : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Height { get; set; }
    public int Area { get { return _points.Count(); } }
    private List<Point> _points;
    static Random _random = new Random();
    static int _minSize = 2;
    static int _maxSize = 9;
    private int _size = _random.Next(_minSize, _maxSize + 1);

    public Triangle(ConsoleColor color, char theChar = '#')
    {
        Top = _random.Next(1, Console.WindowHeight - _size);
        Left = _random.Next(Console.WindowWidth - _size);
        TheChar = theChar;
        Color = color;
        _points = new List<Point>();

        for (int y = 0; y < _size; y++)
            for (int x = 0; x <= y; x++)
                _points.Add(new Point(Left + x, Top + y));
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