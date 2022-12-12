class Square : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Area { get { return _points.Count(); } }
    private List<Point> _points;
    static Random _random = new Random();
    static int _minSize = 3;
    static int _maxSize = 10;
    private int _size = _random.Next(_minSize, _maxSize + 1);

    public Square(ConsoleColor color, char theChar = 'ם')
    {
        Top = _random.Next(1, Console.WindowHeight - _size);
        Left = _random.Next(Console.WindowWidth - _size);
        Color = color;
        TheChar = theChar;
        _points = new List<Point>();

        for (int i = 0; i < _size; i++)
            for (int j = 0; j < _size; j++)
                _points.Add(new Point(Left + j, Top + i));
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