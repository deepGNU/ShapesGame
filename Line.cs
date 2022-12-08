class Line : IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public int Length { get; set; }
    public ConsoleColor Color { get; set; }
    public List<Point> Points { get; set; }
    private Random random = new Random();
    private int _minLength = 2;
    private int _maxLength = 10;


    public Line(Point topLeft, ConsoleColor color = ConsoleColor.Red, char theChar = '=')
    {
        Top = topLeft.Y;
        Left = topLeft.X;
        Color = color;
        TheChar = theChar;
        Length = random.Next(_minLength, _maxLength + 1);
        Points = new List<Point>();
    }

    public void Draw()
    {
        Console.SetCursorPosition(Left, Top);
        Console.ForegroundColor = Color;
        for (int i = 0; i < Length; i++)
        {
            Console.Write(TheChar);
            Points.Add(new Point(Left + i, Top));
        }
    }

    public bool IsHit(Point p)
    {
        foreach (var point in Points)
            if (point.Equals(p)) return true;
        return false;
    }
}