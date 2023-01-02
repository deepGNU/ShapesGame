class Line : Shape
{
    public Line(char theChar = '=')
        : base(theChar) { }

    private const int MIN_LENGTH = 2;
    private const int MAX_LENGTH = 10;
    private int _length;

    protected override void SetDimensions()
    {
        _length = _random.Next(MIN_LENGTH, MAX_LENGTH + 1);
    }

    protected override void SetTopLeft()
    {
        Point point = Board.GetRandomPoint(Board.MaxX - _length + 1);
        (Left, Top) = (point.X, point.Y);
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int x = 0; x < _length; x++)
            Points.Add(new Point(Left + x, Top));
    }

    public override void Shrink()
    {
        if (_length > MIN_LENGTH) _length--;
        SetPoints();
    }
}