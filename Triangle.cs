class Triangle : Shape
{
    public int Height { get; set; }
    static int _minSize = 2;
    static int _maxSize = 9;
    private int _size;

    public Triangle(ConsoleColor color, string theChar = "#")
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
        for (int y = 0; y < _size; y++)
            for (int x = 0; x <= y; x++)
                _points.Add(new Point(Left + x, Top + y));
    }

    public override void Shrink()
    {
        if (_size > _minSize) _size--;
    }
}