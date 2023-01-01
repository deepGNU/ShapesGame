class RandomShapeList
{
    private List<Shape> shapes = new List<Shape>();
    static Func<Shape>[] shapeCtorArr = {
                                          () => new Line(),
                                          () => new Square(),
                                          () => new Rectangle(),
                                          () => new Triangle()
                                        };

    public RandomShapeList(int numShapes)
    {
        for (int i = 0; i < numShapes; i++)
            AddShape();

        foreach (var shape in shapes)
            shape.Draw();
    }

    private void AddShape()
    {
        const int MAX_COUNT = 9;
        int count = 0;
        Shape newShape = GetRandomShape();

        while (OverlapsOtherShape(newShape))
        {
            newShape = GetRandomShape();
            if (++count == MAX_COUNT) ShrinkShapes();
            count %= MAX_COUNT;
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