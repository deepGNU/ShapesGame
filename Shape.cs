abstract class Shape
{
    protected Shape(char theChar)
    {
        TheChar = theChar;
        Color = RandomColor.Get();
        SetDimensions();
        SetTopLeft();
        SetPoints();
    }

    protected int Top { get; set; }
    protected int Left { get; set; }
    protected char TheChar { get; set; }
    protected List<Point> Points { get; set; }
    private ConsoleColor Color { get; set; }
    protected static Random _random = new();

    public void Draw()
    {
        foreach (var point in Points)
            point.Draw(TheChar, Color);
    }

    public void MarkHit()
    {
        foreach (var point in Points)
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
        foreach (var point in otherShape.Points)
            if (IsHit(point)) return true;
        return false;
    }

    abstract protected void SetTopLeft();
    abstract protected void SetDimensions();
    abstract protected void SetPoints();
    abstract public void Shrink();
}