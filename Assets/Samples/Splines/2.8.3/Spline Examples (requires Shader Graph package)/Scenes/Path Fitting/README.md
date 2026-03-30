# Paint Spline Sample

This sample demonstrates how to create a spline from a collection of points.

To view this example, enter Play mode, then click and drag to draw a spline.

Some parameters are provided to control the appearance of the new spline:

**Point Reduction Epsilon** defines the maximum distance an input point can be from the simplified line that is used to construct the spline control points. Lower values will result in a spline that more closely matches the original input points, at the cost of more knots in the spline. Higher values create a spline with less resemblance to the original line, but with fewer knots.

**Spline Tension** defines the `Tension` value used to calculate tangent magnitude. Lower values result in sharp curves, whereas higher values produce rounder curves.

The **Input Sample Count** line shows the number of sample points in the original line.

The **Spline Knot Count** line shows the number knots used to create the spline.