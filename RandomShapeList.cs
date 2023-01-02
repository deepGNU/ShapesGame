class RandomShapeList
{
    public RandomShapeList(int numShapes)
    {
        for (int i = 0; i < numShapes; i++)
            AddShape();
    }

    private List<Shape> shapes = new List<Shape>();
    static Func<Shape>[] shapeCtorArr = {
                                          () => new Line(),
                                          () => new Square(),
                                          () => new Rectangle(),
                                          () => new Triangle()
                                        };

    public void Draw()
    {
        foreach (var shape in shapes)
            shape.Draw();
        Console.ResetColor();
    }

    private void AddShape()
    {
        const int MAX_COUNT = 10;
        int count = 0;
        Shape newShape = GetRandomShape();

        while (OverlapsOtherShape(newShape))
        {
            if (++count == MAX_COUNT) ShrinkShapes();
            count %= MAX_COUNT;
            newShape = GetRandomShape();
        }

        shapes.Add(newShape);
    }

    public bool IsHit(Point point)
    {
        foreach (var shape in shapes)
            if (shape.IsHit(point)) return true;
        return false;
    }

    public void MarkHit(Point point)
    {
        foreach (var shape in shapes)
            if (shape.IsHit(point)) { shape.MarkHit(); break; }
    }

    private static Shape GetRandomShape()
    {
        int randomShapeCtorIndex = new Random().Next(shapeCtorArr.Length);
        Func<Shape> randomShapeCtor = shapeCtorArr[randomShapeCtorIndex];
        return randomShapeCtor();
    }

    private bool OverlapsOtherShape(Shape shape)
    {
        foreach (var otherShape in shapes)
            if (shape.AreaOverlaps(otherShape)) return true;
        return false;
    }

    private void ShrinkShapes()
    {
        foreach (var shape in shapes)
            shape.Shrink();
    }
}