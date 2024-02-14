using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class ColourfulPoint : Point
    {
        public PointColour Colour { get; private set; }

        public ColourfulPoint(decimal x, decimal y, PointColour colour) : base(x, y) 
        {
            Colour = colour;
        }

        public void ChangeColour(PointColour colour) => Colour = colour;

        public void NextColour(){
            switch (Colour) {
                 case PointColour.Red:
                    Colour = PointColour.Green;
                    break;
                 case PointColour.Green:
                    Colour = PointColour.Blue;
                    break;
                 case PointColour.Blue:
                    Colour = PointColour.Red;
                    break;
            }
        }

        public void Normalize(){
            decimal magnitude = (decimal)Math.Sqrt((double)(X * X + Y * Y));
            if (magnitude != 0)
            {
                _x /= magnitude;
                _y /= magnitude;
            }
        }

        public void Add(Point point)
        {
            _x += point.X;
            _y += point.Y;
        }

        public static Point Add(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public override bool IsOnAxis()
        {
            if (base.IsOnAxis() || Colour == PointColour.Blue) return true;
            return false;
        }

        public override string ToString()
        {
            return $"({X},{Y}, {Colour})";
        }
    }
}
