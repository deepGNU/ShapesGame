class Line : Shape
{
    public int Length { get; set; }
    private int _minLength = 2;
    private int _maxLength = 10;

    public Line(ConsoleColor color, string theChar = "=")
        : base(color, theChar) { }

    protected override void SetTopLeft()
    {
        Top = _random.Next(1, Console.WindowHeight - 1);
        Left = _random.Next(1, Console.WindowWidth - Length);
    }

    protected override void SetDimensions()
    {
        Length = _random.Next(_minLength, _maxLength + 1);
    }

    protected override void SetPoints()
    {
        for (int i = 0; i < Length; i++)
            _points.Add(new Point(Left + i, Top));
    }

    public override void Shrink()
    {
        if (Length > _minLength) Length--;
    }
}