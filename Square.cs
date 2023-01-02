class Square : Shape
{
    public Square(char theChar = 'ם')
        : base(theChar) { }

    private const int MIN_SIZE = 3;
    private const int MAX_SIZE = 10;
    private int _size;

    protected override void SetDimensions()
    {
        _size = _random.Next(MIN_SIZE, MAX_SIZE + 1);
    }

    protected override void SetTopLeft()
    {
        Point point = Board.GetRandomPoint(Board.MaxX - _size + 1, Board.MaxY - _size + 1);
        (Left, Top) = (point.X, point.Y);
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int y = 0; y < _size; y++)
            for (int x = 0; x < _size; x++)
                Points.Add(new Point(Left + x, Top + y));
    }

    public override void Shrink()
    {
        if (_size > MIN_SIZE) _size--;
        SetPoints();
    }
}