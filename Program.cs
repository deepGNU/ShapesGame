Snake snek;
List<IShape> shapes = new List<IShape>();
Random _random = new Random();
int screenWidth = Console.WindowWidth;
int screenHeight = Console.WindowHeight;
Console.CursorVisible = false;

// while (true) PlayRound();

// void PlayRound()
// {
//     Console.Clear();
//     snek = new Snake(RandomPointOnScreen());
//     Console.CursorVisible = false;
//     // Console.SetWindowSize(80, 25); 

//     // shapes = new IShape[]
//     // {
//     //     new Line(RandomPointOnScreen()),
//     //     new Triangle(RandomPointOnScreen()),
//     //     new Square(RandomPointOnScreen(), RandomColor()),
//     //     new Rectangle(RandomPointOnScreen())
//     // };

//     foreach (var shape in shapes) shape.Draw();
//     while (snek.Move() && NoShapeHits()) ;
// }

// snek = new Snake(RandomPointOnScreen());
// Console.CursorVisible = false;
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

    foreach (var shape in shapes) shape.Draw();

    while (NoShapeHits())
    {
        ConsoleKey pressedKey = Console.ReadKey(true).Key;

        switch (pressedKey)
        {
            case ConsoleKey.UpArrow:
                snek.MoveUp();
                break;
            case ConsoleKey.DownArrow:
                snek.MoveDown();
                break;
            case ConsoleKey.RightArrow:
                snek.MoveRight();
                break;
            case ConsoleKey.LeftArrow:
                snek.MoveLeft();
                break;
            default:
                break;
        }
    }
}

bool NoShapeHits()
{
    foreach (var shape in shapes)
        if (shape.IsHit(snek.Head)) return false;
    return true;
}

Point RandomPointOnScreen()
{
    int x = _random.Next(screenWidth);
    int y = _random.Next(screenHeight);
    return new Point(x, y);
}

ConsoleColor RandomColor()
{
    var colors = ((IEnumerable<ConsoleColor>)
        Enum.GetValues(typeof(ConsoleColor)))
        .Where(x => x != ConsoleColor.Black).ToArray();

    return (ConsoleColor)colors.GetValue(_random.Next(colors.Length));
}