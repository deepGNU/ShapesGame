class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    static Random _random= new Random();

    public Point() { }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point Clone()
    {
        return new Point(X, Y);
    }

    public bool Equals(Point p)
    {
        return p.X == X && p.Y == Y;
    }

    //public void Draw(char charToDraw, ConsoleColor color)
    //{
    //    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("he-IL");
    //    System.Threading.Thread.CurrentThread.CurrentCulture = ci;
    //    // Set the text alignment of the console to LTR
    //    System.Console.SetWindowPosition(0, 0);
    //    System.Console.SetWindowSize(System.Console.WindowWidth, System.Console.WindowHeight);

    //    Console.ForegroundColor = color;
    //    Console.SetCursorPosition(X, Y);
    //    Console.Write(charToDraw);
    //}

    public void Draw(char charToDraw, ConsoleColor color)
    {
        // Set the text alignment of the console to LTR
        System.Console.SetWindowPosition(0, 0);
        System.Console.SetWindowSize(System.Console.WindowWidth, System.Console.WindowHeight);
        // Set the output encoding of the console to UTF-8
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.ForegroundColor = color;
        //Console.SetCursorPosition(X, Y);
        Console.CursorLeft = X;
        Console.CursorTop = Y;
        Console.Write(charToDraw);
    }


    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static Point GetRandom(int maxX, int maxY, int minX = 0, int minY = 0)
    {
        int x = _random.Next(minX, maxX);
        int y = _random.Next(minY, maxY);
        return new Point(x, y);
    }
}