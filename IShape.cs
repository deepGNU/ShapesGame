interface IShape
{
    public int Top { get; set; }
    public int Left { get; set; }
    public char TheChar { get; set; }
    public ConsoleColor Color { get; set; }
    public int Area { get; }
    //public List<Point> Points { get; set; }
    public void Draw();
    public bool IsHit(Point p);
}