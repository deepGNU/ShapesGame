class Triangle : Shape
{
    static int _minSize = 2;
    static int _maxSize = 9;
    private int _size;

    public Triangle(char theChar = '#')
        : base(theChar) { }

    protected override void SetTopLeft()
    {
        Point point = Board.GetRandomPoint(Board.MaxX - _size + 1, Board.MaxY - _size + 1);
        (Left, Top) = (point.X, point.Y);
        //Top = _random.Next(1, Console.WindowHeight - _size);
        //Left = _random.Next(1, Console.WindowWidth - _size);
    }

    protected override void SetDimensions()
    {
        _size = _random.Next(_minSize, _maxSize + 1);
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int y = 0; y < _size; y++)
            for (int x = 0; x <= y; x++)
                Points.Add(new Point(Left + x, Top + y));
    }

    public override void Shrink()
    {
        if (_size > _minSize) _size--;
        SetPoints();
    }
}