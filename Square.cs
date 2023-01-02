class Square : Shape
{
    static int _minSize = 3;
    static int _maxSize = 10;
    private int _size;

    public Square(char theChar = 'ם')
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
        //_size = _random.Next(_minSize, _maxSize + 1);
        _size = _maxSize;
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int i = 0; i < _size; i++)
            for (int j = 0; j < _size; j++)
                Points.Add(new Point(Left + j, Top + i));
    }

    public override void Shrink()
    {
        if (_size > _minSize) _size--;
        SetPoints();
    }
}