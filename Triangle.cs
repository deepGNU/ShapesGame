class Triangle : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Height { get; set; }
    public List<Point> Points { get; set; }
    static Random _rand = new Random();
    static int _minSize = 2;
    static int _maxSize = 9;
    private int _size = _rand.Next(_minSize, _maxSize + 1);

    public Triangle(Point topLeft, ConsoleColor color = ConsoleColor.Green, char theChar = '#')
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
        for (int i = 0; i < _size; i++)
        {
            Console.SetCursorPosition(Left, Top + i);
            for (int j = 0; j < i; j++)
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