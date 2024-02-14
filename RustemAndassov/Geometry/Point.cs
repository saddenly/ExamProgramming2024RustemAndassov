using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point : IReflectable
    {
        protected decimal _x;
        protected decimal _y;

        public decimal X => _x;
        public decimal Y => _y;

        public Point(decimal input)
        {
            _x = input;
            _y = 0;
        }

        public Point(decimal x, decimal y) 
        {
            _x = x; 
            _y = y;
        }

        public void ReflectX()
        {
            _x *= -1;
        }

        public void ReflectY()
        {
            _y *= -1;
        }

        public virtual bool IsOnAxis(){
            if (X == 0 || Y == 0) return true;
            return false;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
