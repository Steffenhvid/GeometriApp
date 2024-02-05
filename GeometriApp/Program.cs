using GeometriApp.Models;
using GeometriApp.Services;

var z1 = new Coordinate(2, 4);
var z2 = new Coordinate(2, 1);
var v1 = new Coordinate(1, 2);
var v2 = new Coordinate(5, 2);

var line1 = new Line(z1, z2);
var line2 = new Line(v1, v2);

var intersect = line1.CalculateIntersect(line2);
Console.WriteLine(intersect?.X);
Console.WriteLine(intersect?.Y);