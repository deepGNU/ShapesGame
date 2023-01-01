abstract class Shape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Area { get { return Points.Count(); } }
    protected static Random _random = new();
    public List<Point> Points;

    public Shape(char theChar)
    {
        TheChar = theChar;
        Color = GetRandomColor();
        SetDimensions();
        SetTopLeft();
        SetPoints();
    }

    public void Draw()
    {
        foreach (Point point in Points)
            point.Draw(TheChar, Color);
    }

    public void MarkHit()
    {
        foreach (Point point in Points)
            point.Draw('X', ConsoleColor.White);
    }

    public bool IsHit(Point p)
    {
        foreach (var point in Points)
            if (point.Equals(p)) return true;
        return false;
    }

    public bool AreaOverlaps(Shape otherShape)
    {
        foreach (Point point in otherShape.Points)
            if (IsHit(point)) return true;
        return false;
    }

    //public void Relocate()
    //{
    //    SetTopLeft();
    //    Points = new List<Point>();
    //    SetPoints();
    //}

    static ConsoleColor GetRandomColor()
    {
        Array colors = ((IEnumerable<ConsoleColor>)
            Enum.GetValues(typeof(ConsoleColor)))
            .Where(x => x != ConsoleColor.Black).ToArray();

        return (ConsoleColor)colors.GetValue(_random.Next(colors.Length));
    }

    abstract protected void SetTopLeft();
    abstract protected void SetDimensions();
    abstract protected void SetPoints();
    abstract public void Shrink();
}