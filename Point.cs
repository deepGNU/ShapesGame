class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    static Random _random= new Random();

    public Point() { }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point Clone()
    {
        return new Point(X, Y);
    }

    public bool Equals(Point p)
    {
        return p.X == X && p.Y == Y;
    }

    public void Draw(char charToDraw, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(X, Y);
        Console.Write(charToDraw);
    }

    public static Point GetRandom(int maxX, int maxY, int minX = 0, int minY = 0)
    {
        int x = _random.Next(minX, maxX);
        int y = _random.Next(minY, maxY);
        return new Point(x, y);
    }
}