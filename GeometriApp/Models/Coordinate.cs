using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometriApp.Models
{
    public class Coordinate
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public Coordinate(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Coordinate;
            if (other == null)
                return false;

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}