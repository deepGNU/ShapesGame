class Rectangle : Shape
{
    public Rectangle(char theChar = 'ם')
        : base(theChar) { }

    private const int MIN_LENGTH = 2;
    private const int MAX_LENGTH = 10;
    private int _width;
    private int _height;

    protected override void SetDimensions()
    {
        _width = _random.Next(MIN_LENGTH, MAX_LENGTH + 1);
        _height = _random.Next(MIN_LENGTH, MAX_LENGTH + 1);
    }

    protected override void SetTopLeft()
    {
        Point point = Board.GetRandomPoint(Board.MaxX - _width + 1, Board.MaxY - _height + 1);
        (Left, Top) = (point.X, point.Y);
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int y = 0; y < _height; y++)
            for (int x = 0; x < _width; x++)
                Points.Add(new Point(Left + x, Top + y));
    }

    public override void Shrink()
    {
        if (_width > MIN_LENGTH) _width--;
        if (_height > MIN_LENGTH) _height--;
        SetPoints();
    }
}