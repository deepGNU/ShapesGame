class Rectangle : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public List<Point> Points { get; set; }
    static Random _rand = new Random();
    static int _minLength = 2;
    static int _maxLength = 10;
    private int _width = _rand.Next(_minLength, _maxLength + 1);
    private int _height = _rand.Next(_minLength, _maxLength + 1);

    public Rectangle(Point topLeft, ConsoleColor color = ConsoleColor.DarkMagenta, char theChar = 'ם')
    {
        Top = topLeft.Y;
        Left = topLeft.X;
        TheChar = theChar;
        Color = color;
        Points = new List<Point>();
    }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        for (int i = 0; i < _height; i++)
        {
            Console.SetCursorPosition(Left, Top + i);
            for (int j = 0; j < _width; j++)
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