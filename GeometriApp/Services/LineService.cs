using GeometriApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GeometriApp.Services
{
    public static class LineService
    {
        public static Coordinate? CalculateIntersect(this Line line1, Line line2)
        {
            if (line1.LineIsParallelWith(line2))
                return null;
            decimal? x;
            decimal? y;

            if (line1.Vertical && line2.Horizontal)
            {
                x = line1.Coordinate1.X;
                y = line2.Coordinate1.Y;
            }
            else if (line1.Horizontal && line2.Vertical)
            {
                x = line2.Coordinate1.X;
                y = line1.Coordinate1.Y;
            }
            else if (line1.Vertical)
            {
                x = line1.Coordinate1.X;
                y = line2.Slope * x + line2.Intersect;
            }
            else if (line2.Vertical)
            {
                x = line2.Coordinate1.X;
                y = line1.Slope * x + line1.Intersect;
            }
            else if (line1.Horizontal)
            {
                y = line1.Coordinate1.Y;
                x = (y - line2.Intersect) / line2.Slope;
            }
            else if (line2.Horizontal)
            {
                y = line2.Coordinate1.Y;
                x = (y - line1.Intersect) / line1.Slope;
            }
            else
            {
                x = (line2.Intersect - line1.Intersect) / (line1.Slope - line2.Slope);
                y = line1.Slope * x + line1.Intersect;
            }

            if (x is null || y is null)
                return null;

            return new Coordinate(x.Value, y.Value);
        }

        public static bool LineIsParallelWith(this Line line1, Line line2)
        {
            bool verticalLines = line1.Vertical && line2.Vertical;
            bool horisontalLines = line1.Horizontal && line2.Horizontal;
            bool sameSlope = line1.Slope == line2.Slope;
            return verticalLines || horisontalLines || sameSlope;
        }
    }
}