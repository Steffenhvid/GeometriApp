using GeometriApp.Models;
using GeometriApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometriApp.Tests.Services
{
    public class LineServiceTests
    {
        #region Intersection Tests

        [Fact]
        public void OrderOfLinesAreIrrelevant()
        {
            Coordinate z1 = new(2, 5);
            Coordinate z2 = new(6, 1);
            Coordinate v1 = new(2, 1);
            Coordinate v2 = new(6, 5);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);
            Coordinate? ic2 = l2.CalculateIntersect(l1);

            Assert.NotNull(ic1);
            Assert.NotNull(ic2);

            Assert.Equal(ic1, ic2);
        }

        [Fact]
        public void OneLineIsVertical_ReturnsIntersect()
        {
            Coordinate expectedCoordinate = new Coordinate(2, 2);

            Coordinate z1 = new(2, 3);
            Coordinate z2 = new(2, 1);
            Coordinate v1 = new(1, 1);
            Coordinate v2 = new(3, 3);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);

            Assert.Equal(expectedCoordinate, ic1);
        }

        [Fact]
        public void OneLineIsVerticaAndOneLineIsHorizontal_ReturnsIntersect()
        {
            Coordinate expectedCoordinate = new Coordinate(2, 2);

            Coordinate z1 = new(1, 2);
            Coordinate z2 = new(3, 2);
            Coordinate v1 = new(2, 3);
            Coordinate v2 = new(2, 1);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);

            Assert.Equal(expectedCoordinate, ic1);
        }

        [Fact]
        public void TwoLineIsVertical_ReturnsNull()
        {
            Coordinate z1 = new(1, 2);
            Coordinate z2 = new(1, 1);
            Coordinate v1 = new(2, 1);
            Coordinate v2 = new(2, 2);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);
            Assert.Null(ic1);
        }

        [Fact]
        public void OneLineIsHorizontal_ReturnsIntersect()
        {
            Coordinate expectedCoordinate = new Coordinate(2, 2);

            Coordinate z1 = new(1, 1);
            Coordinate z2 = new(3, 3);
            Coordinate v1 = new(1, 2);
            Coordinate v2 = new(3, 2);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);

            Assert.Equal(expectedCoordinate, ic1);
        }

        [Fact]
        public void TwoLineIsHorizontal_ReturnsNull()
        {
            Coordinate z1 = new(1, 2);
            Coordinate z2 = new(2, 2);
            Coordinate v1 = new(1, 1);
            Coordinate v2 = new(2, 1);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);
            Assert.Null(ic1);
        }

        [Fact]
        public void ParallelPositiveSlope_ReturnsNull()
        {
            Coordinate z1 = new(1, 1);
            Coordinate z2 = new(2, 2);
            Coordinate v1 = new(2, 1);
            Coordinate v2 = new(3, 2);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);
            Assert.Null(ic1);
        }

        [Fact]
        public void ParallelNegativeSlope_ReturnsNull()
        {
            Coordinate z1 = new(1, 2);
            Coordinate z2 = new(2, 1);
            Coordinate v1 = new(2, 2);
            Coordinate v2 = new(3, 1);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);
            Assert.Null(ic1);
        }

        [Fact]
        public void RegularCase_ReturnsIntersect()
        {
            Coordinate expectedCoordinate = new Coordinate(4, 3);
            Coordinate z1 = new(2, 5);
            Coordinate z2 = new(6, 1);
            Coordinate v1 = new(2, 1);
            Coordinate v2 = new(6, 5);

            Line l1 = new(z1, z2);
            Line l2 = new(v1, v2);

            Coordinate? ic1 = l1.CalculateIntersect(l2);

            Assert.Equal(expectedCoordinate, ic1);
        }

        #endregion Intersection Tests
    }
}