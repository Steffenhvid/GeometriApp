using GeometriApp.Models;
using Microsoft.FSharp.Collections;
using Plotly.NET.LayoutObjects;
using Plotly.NET;
using GeometriApp.Services;

Coordinate z1 = new(1, 1);
Coordinate z2 = new(5, 3);
Coordinate v1 = new(1, 5);
Coordinate v2 = new(3, 1);
Coordinate u1 = new(1, -2);
Coordinate u2 = new(5, -1);
var line1 = new GeometriApp.Models.Line(z1, z2);
var line2 = new GeometriApp.Models.Line(v1, v2);
var line3 = new GeometriApp.Models.Line(u1, u2);

LinearAxis xAxis = new LinearAxis();
xAxis.SetValue("title", "xAxis");
xAxis.SetValue("zerolinecolor", "#ffff");
xAxis.SetValue("gridcolor", "#ffff");
xAxis.SetValue("showline", true);
xAxis.SetValue("zerolinewidth", 2);

LinearAxis yAxis = new LinearAxis();
yAxis.SetValue("title", "yAxis");
yAxis.SetValue("zerolinecolor", "#ffff");
yAxis.SetValue("gridcolor", "#ffff");
yAxis.SetValue("showline", true);
yAxis.SetValue("zerolinewidth", 2);

Layout layout = new Layout();
layout.SetValue("xaxis", xAxis);
layout.SetValue("yaxis", yAxis);
layout.SetValue("title", "Intersection");
layout.SetValue("plot_bgcolor", "#e5ecf6");
layout.SetValue("showlegend", true);

Trace l1 = new Trace("line");
l1.SetValue("x", new[] { line1.Coordinate1.X, line1.Coordinate2.X });
l1.SetValue("y", new[] { line1.Coordinate1.Y, line1.Coordinate2.Y });
l1.SetValue("name", "Line One");

Trace l2 = new Trace("line");
l2.SetValue("x", new[] { line2.Coordinate1.X, line2.Coordinate2.X });
l2.SetValue("y", new[] { line2.Coordinate1.Y, line2.Coordinate2.Y });
l2.SetValue("name", "Line Two");

Trace l3 = new Trace("line");
l3.SetValue("x", new[] { line3.Coordinate1.X, line3.Coordinate2.X });
l3.SetValue("y", new[] { line3.Coordinate1.Y, line3.Coordinate2.Y });
l3.SetValue("name", "Line Three");

Coordinate? intersect1 = line1.CalculateIntersect(line2);
Trace p1 = new Trace("point");
p1.SetValue("x", new[] { intersect1?.X });
p1.SetValue("y", new[] { intersect1?.Y });
p1.SetValue("name", "Intersect");

Coordinate? intersect2 = line2.CalculateIntersect(line3);
Trace p2 = new Trace("point");
p2.SetValue("x", new[] { intersect2?.X });
p2.SetValue("y", new[] { intersect2?.Y });
p2.SetValue("name", "Intersect");

var fig = GenericChart.Figure.create(ListModule.OfSeq(new[] { l1, l2, l3, p1, p2 }), layout);
GenericChart.fromFigure(fig).Show();