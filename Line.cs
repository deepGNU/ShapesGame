class Line : Shape
{
    private static int _minLength = 2;
    private static int _maxLength = 10;
    private int _length;

    public Line(char theChar = '=')
        : base(theChar) { }

    protected override void SetTopLeft()
    {
        Top = _random.Next(1, Console.WindowHeight - 1);
        Left = _random.Next(1, Console.WindowWidth - _length);
    }

    protected override void SetDimensions()
    {
        _length = _random.Next(_minLength, _maxLength + 1);
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int i = 0; i < _length; i++)
            Points.Add(new Point(Left + i, Top));
    }

    public override void Shrink()
    {
        if (_length > _minLength) _length--;
        SetPoints();
    }
}