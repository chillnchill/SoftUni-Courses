using System;


namespace T00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');


            Rectangle rectangle = new Rectangle()
            {
                Top = 6,
                Left = 6,

            };
        }
    }
}

class Rectangle
{
    public int Top { get; set; }
    public int Left { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Area
    {
        get
        {
            return Width * Height;
        }

    }

}
