using System;
using Geometry;

namespace GeometryTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 2);
            ColourfulPoint colourfulPoint = new ColourfulPoint(3, 4, PointColour.Red);

            Console.WriteLine($"Point1: X={point1.X}, Y={point1.Y}");
            Console.WriteLine($"ColourfulPoint: X={colourfulPoint.X}, Y={colourfulPoint.Y}, Colour={colourfulPoint.Colour}");

            colourfulPoint.ReflectX();
            Console.WriteLine($"After ReflectX: {colourfulPoint}");

            colourfulPoint.ChangeColour(PointColour.Green);
            Console.WriteLine($"After ChangeColour: {colourfulPoint}");

            colourfulPoint.NextColour();
            Console.WriteLine($"After NextColour: {colourfulPoint}");

            colourfulPoint.Normalize();
            Console.WriteLine($"After Normalize: {colourfulPoint}");

            Point point2 = new Point(1, 1);
            colourfulPoint.Add(point2);
            Console.WriteLine($"After Add: {colourfulPoint}");

            Point sum = ColourfulPoint.Add(point1, point2);
            Console.WriteLine($"Sum of point1 and point2: {sum}");
            Console.ReadKey();
        }
    }
}
