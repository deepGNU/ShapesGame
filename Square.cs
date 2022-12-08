class Square : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public List<Point> Points { get; set; }
    static Random _random = new Random();
    static int _minSize = 3;
    static int _maxSize = 10;
    private int _size = _random.Next(_minSize, _maxSize + 1);

    public Square(Point topLeft, ConsoleColor color, char theChar = 'ם')
    {
        Top = topLeft.Y;
        Left = topLeft.X;
        Color = color;
        TheChar = theChar;
        Points = new List<Point>();
    }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        for (int i = 0; i < _size; i++)
        {
            Console.SetCursorPosition(Left, Top + i);
            for (int j = 0; j < _size; j++)
            {
                Console.Write(TheChar);
                Points.Add(new Point(Left + j, Top + i));
            }
        }
    }

    public bool IsHit(Point p)
    {
        foreach (var point in Points)
            if (point.Equals(p)) return true;
        return false;
    }
}