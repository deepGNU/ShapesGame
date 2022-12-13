abstract class Shape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Area { get { return _points.Count(); } }
    protected Random _random;
    protected List<Point> _points;

    public Shape(ConsoleColor color, char theChar)
    {
        Color = color;
        TheChar = theChar;
        _random = new Random();
        _points = new List<Point>();
        SetDimensions();
        SetTopLeft();
        SetPoints();
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

    public bool AreaOverlaps(Shape otherShape)
    {
        foreach (Point point1 in _points)
            foreach (Point point2 in otherShape._points)
                if (point1.Equals(point2)) return true;
        return false;
    }

    public void Relocate()
    {
        SetTopLeft();
        _points = new List<Point>();
        SetPoints();
    }

    abstract protected void SetTopLeft();
    abstract protected void SetDimensions();
    abstract protected void SetPoints();
    abstract public void Shrink();
}