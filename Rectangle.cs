class Rectangle : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Area { get { return _points.Count(); } }
    public List<Point> _points { get; set; }
    static Random _random = new Random();
    static int _minLength = 2;
    static int _maxLength = 10;
    private int _width = _random.Next(_minLength, _maxLength + 1);
    private int _height = _random.Next(_minLength, _maxLength + 1);

    public Rectangle(ConsoleColor color, char theChar = 'ם')
    {
        Top = _random.Next(1, Console.WindowHeight - _height);
        Left = _random.Next(Console.WindowWidth - _width);
        TheChar = theChar;
        Color = color;
        _points = new List<Point>();

        for (int i = 0; i < _height; i++)
            for (int j = 0; j < _width; j++)
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