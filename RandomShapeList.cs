class RandomShapeList
{
    static Random _random = new Random();
    static Func<Shape>[] shapeCtorArr = { () => new Line(RandomColor()), () => new Square(RandomColor()), () => new Rectangle(RandomColor()), () => new Triangle(RandomColor()) };
    static Func<Shape> RandomShape = () => shapeCtorArr[_random.Next(shapeCtorArr.Length)]();
    private List<Shape> shapes = new List<Shape>();

    public RandomShapeList(int numOfShapes)
    {
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
                    //shapes[j].Shrink();
                    //shapes[i].Relocate();
                    shapes[j].Relocate();
                    CorrectOverlaps();
                }
    }
}