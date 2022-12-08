class Point
{
    public int X { get; set; }
    public int Y { get; set; }

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
}