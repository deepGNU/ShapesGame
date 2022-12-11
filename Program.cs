Snake snek;
List<IShape> shapes = new List<IShape>();
Random _random = new Random();
int maxX = 80;
int maxY = 25;
Console.SetWindowSize(maxX, maxY);
Console.CursorVisible = false;

Type[] types = new Type[]
{ typeof(Line), typeof(Square),
  typeof(Rectangle), typeof(Triangle) };

Dictionary<Type, Func<IShape>> ctorDict =
        new Dictionary<Type, Func<IShape>>();

ctorDict[typeof(Line)] =      () => new Line(RandomColor());
ctorDict[typeof(Square)] =    () => new Square(RandomColor());
ctorDict[typeof(Rectangle)] = () => new Rectangle(RandomColor());
ctorDict[typeof(Triangle)] =  () => new Triangle(RandomColor());

Func<IShape> RandomShape = () => ctorDict[types[_random.Next(types.Length)]]();

for (int numOfShape = 6; numOfShape <= 15; numOfShape++)
{
    PlayRound(numOfShape);
}

Console.Clear();
Console.SetCursorPosition(0, 0);
Console.WriteLine("GAME OVER");
Console.WriteLine($"YOUR SCORE: {Snake.Score}");
Thread.Sleep(9000);

void PlayRound(int numOfShapes)
{
    Console.Clear();

    snek = new Snake(RandomStartPoint());
    shapes = new List<IShape>();

    for (int i = 0; i < numOfShapes; i++)
        shapes.Add(RandomShape());

    foreach (var shape in shapes)
        shape.Draw();

    while (!IsShapeHit(snek.Head) && !snek.IsSteppingOnSelf())
        snek.Move();
}

bool IsShapeHit(Point point)
{
    foreach (var shape in shapes)
        if (shape.IsHit(point)) return true;
    return false;
}

Point RandomStartPoint()
{
    Point point = new Point();
    do
    {
        point.X = _random.Next(maxX);
        point.Y = _random.Next(maxY);
    } while (IsShapeHit(point));
    return point;
}

ConsoleColor RandomColor()
{
    Array colors = ((IEnumerable<ConsoleColor>)
        Enum.GetValues(typeof(ConsoleColor)))
        .Where(x => x != ConsoleColor.Black).ToArray();

    return (ConsoleColor)colors.GetValue(_random.Next(colors.Length));
}