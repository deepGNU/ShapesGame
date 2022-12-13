using System.Diagnostics;

Snake snek;
List<Shape> shapes = new List<Shape>();
Random _random = new Random();
const int MAX_SHAPES = 14;
const int INITAL_SHAPES = 6;
const int TOTAL_ROUNDS = MAX_SHAPES - INITAL_SHAPES + 1;
int maxX = 80;
int maxY = 25;
Console.SetWindowSize(maxX, maxY + 1);
Console.CursorVisible = false;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Type[] types = new Type[]
{ typeof(Line), typeof(Square),
  typeof(Rectangle), typeof(Triangle) };

Dictionary<Type, Func<Shape>> ctorDict =
        new Dictionary<Type, Func<Shape>>();

ctorDict[typeof(Line)] = () => new Line(RandomColor());
ctorDict[typeof(Square)] = () => new Square(RandomColor());
ctorDict[typeof(Rectangle)] = () => new Rectangle(RandomColor());
ctorDict[typeof(Triangle)] = () => new Triangle(RandomColor());

Func<Shape> RandomShape = () => ctorDict[types[_random.Next(types.Length)]]();

Stopwatch stopwatch = Stopwatch.StartNew();

for (int numOfShapes = INITAL_SHAPES; numOfShapes <= MAX_SHAPES; numOfShapes++)
{
    PlayRound(numOfShapes);
}

stopwatch.Stop();

Console.Clear();
Console.SetCursorPosition(0, 0);
Console.WriteLine("GAME OVER");
Console.WriteLine($"YOUR SCORE: {Snake.Score} POINTS");
Console.WriteLine($"NUMBER OF ROUNDS PLAYED: {TOTAL_ROUNDS}");
Console.WriteLine($"ELAPSED TIME: {Math.Round(stopwatch.Elapsed.TotalSeconds, 2, MidpointRounding.ToZero)} SECONDS");
Thread.Sleep(9000);

void PlayRound(int numOfShapes)
{
    Console.Clear();

    shapes = new List<Shape>();

    for (int i = 0; i < numOfShapes; i++)
        shapes.Add(RandomShape());

    CorrectOverlaps();

    foreach (var shape in shapes)
        shape.Draw();

    snek = new Snake(RandomStartPoint());

    while (!IsShapeHit(snek.Head) && !snek.IsSteppingOnSelf())
    {
        PrintGameState(numOfShapes);
        snek.Move();
    }
}

bool IsShapeHit(Point point)
{
    foreach (var shape in shapes)
        if (shape.IsHit(point)) return true;
    return false;
}

Point RandomStartPoint()
{
    Point point;
    do
    {
        point = Point.GetRandom(maxX, maxY, 1, 1);
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

//int GetRemainingArea()
//{
//    return GetTotalArea() - GetShapesArea() - snek.Area;
//}

//int GetShapesArea()
//{
//    return shapes.Aggregate((s1, s2) => s1.Area + s2.Area);
//}

//int GetTotalArea()
//{
//    return maxX * maxY;
//}

void PrintGameState(int numShapes)
{
    Console.SetCursorPosition(0, 0);
    Console.Write($"\tTOTAL SCORE: {Snake.Score}");
    Console.Write(" | ");
    Console.Write($"ROUND {numShapes - INITAL_SHAPES + 1} OUT OF {MAX_SHAPES - INITAL_SHAPES + 1}\t");
}

void CorrectOverlaps()
{
    for (int i = 0; i < shapes.Count(); i++)
    {
        for (int j = i + 1; j < shapes.Count(); j++)
        {
            int n = 1;
            if (shapes[i].AreaOverlaps(shapes[j]))
            {
                shapes[i].Shrink();
                shapes[j].Shrink();
                Console.WriteLine(n++);
                shapes[j].Relocate();
                shapes[i].Relocate();
                CorrectOverlaps();
            }
        }
    }
}