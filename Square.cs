class Square : Shape
{
    static int _minSize = 3;
    static int _maxSize = 10;
    private int _size;
    
    public Square(ConsoleColor color, string theChar = "ם\u200E")
        : base(color, theChar) { }

    protected override void SetTopLeft()
    {
        Top = _random.Next(1, Console.WindowHeight - _size);
        Left = _random.Next(1, Console.WindowWidth - _size);
    }

    protected override void SetDimensions()
    {
        _size = _random.Next(_minSize, _maxSize + 1);
    }

    protected override void SetPoints()
    {
        for (int i = 0; i < _size; i++)
            for (int j = 0; j < _size; j++)
                _points.Add(new Point(Left + j, Top + i));
    }

    public override void Shrink()
    {
        if (_size > _minSize) _size--;
    }
}