Snake snek;
List<IShape> shapes = new List<IShape>();
Random _random = new Random();
int screenWidth = Console.WindowWidth;
int screenHeight = Console.WindowHeight;
Console.CursorVisible = false;
// Console.SetWindowSize(80, 25); 

Type[] types = new Type[]
{ typeof(Line), typeof(Square),
  typeof(Rectangle), typeof(Triangle) };

Dictionary<Type, Func<IShape>> ctorDict =
        new Dictionary<Type, Func<IShape>>();

ctorDict[typeof(Line)] = () => new Line(RandomPointOnScreen(), RandomColor());
ctorDict[typeof(Square)] = () => new Square(RandomPointOnScreen(), RandomColor());
ctorDict[typeof(Rectangle)] = () => new Rectangle(RandomPointOnScreen(), RandomColor());
ctorDict[typeof(Triangle)] = () => new Triangle(RandomPointOnScreen(), RandomColor());

Func<IShape> RandomShape = () => ctorDict[types[_random.Next(types.Length)]]();

for (int numOfShape = 6; numOfShape <= 15; numOfShape++)
{
    PlayRound(numOfShape);
}

void PlayRound(int numOfShapes)
{
    Console.Clear();
    snek = new Snake(RandomPointOnScreen());
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

Point RandomPointOnScreen()
{
    Point point = new Point();
    do
    {
        point.X = _random.Next(screenWidth);
        point.Y = _random.Next(screenHeight);
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