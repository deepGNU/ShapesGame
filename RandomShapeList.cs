class RandomShapeList
{
    static Random _random = new Random();
    static Type[] types = new Type[] { typeof(Line), typeof(Square), typeof(Rectangle), typeof(Triangle) };
    static Dictionary<Type, Func<Shape>> ctorDict = new Dictionary<Type, Func<Shape>>();
    static Func<Shape> RandomShape = () => ctorDict[types[_random.Next(types.Length)]]();
    private List<Shape> shapes = new List<Shape>();

    public RandomShapeList(int numOfShapes)
    {
        ctorDict[typeof(Line)] = () => new Line(RandomColor());
        ctorDict[typeof(Square)] = () => new Square(RandomColor());
        ctorDict[typeof(Rectangle)] = () => new Rectangle(RandomColor());
        ctorDict[typeof(Triangle)] = () => new Triangle(RandomColor());

        for (int i = 0; i < numOfShapes; i++)
            shapes.Add(RandomShape());

        CorrectOverlaps();

        List<Shape> sortedShapes = shapes.OrderBy(shape => shape.Left).ToList();

        foreach (var shape in sortedShapes)
            shape.Draw();
    }

    public bool IsHit(Point point)
    {
        foreach (var shape in shapes)
            if (shape.IsHit(point)) return true;
        return false;
    }

    static ConsoleColor RandomColor()
    {
        Array colors = ((IEnumerable<ConsoleColor>)
            Enum.GetValues(typeof(ConsoleColor)))
            .Where(x => x != ConsoleColor.Black).ToArray();

        return (ConsoleColor)colors.GetValue(_random.Next(colors.Length));
    }

    private void CorrectOverlaps()
    {
        for (int i = 0; i < shapes.Count(); i++)
            for (int j = i + 1; j < shapes.Count(); j++)
                if (shapes[i].AreaOverlaps(shapes[j]))
                {
                    shapes[i].Shrink();
                    shapes[j].Shrink();
                    shapes[i].Relocate();
                    shapes[j].Relocate();
                    CorrectOverlaps();
                }
    }
}