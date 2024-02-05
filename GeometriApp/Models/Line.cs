using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GeometriApp.Models
{
    public class Line
    {
        public Coordinate Coordinate1 { get; set; }
        public Coordinate Coordinate2 { get; set; }

        /// <summary>
        /// Returns true if line is vertical
        /// </summary>
        public bool Vertical => Coordinate1.X == Coordinate2.X;

        /// <summary>
        /// Returns true if line i Horizontal
        /// </summary>
        public bool Horizontal => Coordinate1.Y == Coordinate2.Y;

        /// <summary>
        /// Returns the slope, if the line is Vertical, it returns null.
        /// </summary>
        public decimal? Slope => CalculateSlope();

        /// <summary>
        /// Returns the intersect, if the line is Vertical it returns null.
        /// </summary>
        public decimal? Intersect => CalculateIntercept();

        private decimal? CalculateIntercept()
        {
            if (Vertical)
                return null;
            return Coordinate1.Y - Slope * Coordinate1.X;
        }

        private decimal? CalculateSlope()
        {
            if (Vertical)
                return null;
            if (Horizontal)
                return 0;
            return (Coordinate2.Y - Coordinate1.Y) / (Coordinate2.X - Coordinate1.X);
        }

        public Line(Coordinate coordinate1, Coordinate coordinate2)
        {
            Coordinate1 = coordinate1;
            Coordinate2 = coordinate2;
        }
    }
}