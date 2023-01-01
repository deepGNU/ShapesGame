class Rectangle : Shape
{
    static int _minLength = 2;
    static int _maxLength = 10;
    private int _width;
    private int _height;

    public Rectangle(char theChar = 'ם')
        : base(theChar) { }

    protected override void SetTopLeft()
    {
        Top = _random.Next(1, Console.WindowHeight - _height);
        Left = _random.Next(1, Console.WindowWidth - _width);
    }

    protected override void SetDimensions()
    {
        _width = _random.Next(_minLength, _maxLength + 1);
        _height = _random.Next(_minLength, _maxLength + 1);
    }

    protected override void SetPoints()
    {
        Points = new List<Point>();
        for (int i = 0; i < _height; i++)
            for (int j = 0; j < _width; j++)
                Points.Add(new Point(Left + j, Top + i));
    }

    public override void Shrink()
    {
        if (_width > _minLength) _width--;
        if (_height > _minLength) _height--;
        SetPoints();
    }
}