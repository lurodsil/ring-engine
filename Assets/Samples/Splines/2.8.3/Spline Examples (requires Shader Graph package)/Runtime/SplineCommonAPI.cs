using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

/// <summary>
/// Collection of commonly used functions in the Spline package.
/// </summary>
class SplineExamples : MonoBehaviour
{
    void Example()
    {
        // Splines exist in a scene as properties in a SplineContainer. The relationship of splines to SplineContainer
        // is similar to the relationship between Mesh and MeshFilter.
        var container = GetComponent<SplineContainer>();

        // SplineContainer can hold many splines. Access those splines through the Splines property.
        IReadOnlyList<Spline> splines = container.Splines;

        // Get the position along a spline at a ratio from 0 to 1. 0 is the beginning of the spline and 1 is the end of the spline.
        // Call the SplineContainer version of EvaluatePosition to get results in world space.
        float3 worldPosition = container.EvaluatePosition(.5f);

        // Get the position, tangent, and direction of a spline at a location along a spline, and then rotate a GameObject to match the position and rotation of the spline.
        container.Evaluate(.3f, out var position, out var tangent, out var normal);
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(tangent);

        // Knot connections are stored in the KnotLinkConnection type.
        var links = container.KnotLinkCollection;

        // Knots are referenced by an index to the SplineContainer.Splines array and Knot Index.
        // This example queries whether any knots are linked to the fourth knot of the first spline.
        var knotIndex = new SplineKnotIndex(0, 3);
        if (links.TryGetKnotLinks(knotIndex, out var linked))
            Debug.Log($"found {linked.Count} connected knots!");

        // SplineSlice represents a partial or complete range of curves from another spline. Slices can iterate either forwards or backwards.
        // A slice is a value type and does not make copies of the referenced spline. A slice is not resource intensive to create.
        // Create a new spline from the first curve of another spline.
        var slice = new SplineSlice<Spline>(splines.First(), new SplineRange(0, 2));

        // Create a SplinePath to evaluate multiple slices of many splines as a single path.
        var path = new SplinePath(new SplineSlice<Spline>[]
        {
            slice,
            // This range starts at the fourth knot and iterates backwards by three indices.
            new SplineSlice<Spline>(splines[1], new SplineRange(3, -3))
        });

        // SplinePath implements ISpline, which you can evaluate with any of the usual SplineUtility methods.
        var _ = path.EvaluatePosition(.42f);

        // If performance is a concern, use NativeSpline. NativeSpline is a NativeArray backed representation of
        // any ISpline type. NativeSpline is very efficient to query because all transformations are baked at construction.
        // Unlike Spline, NativeSpline is not mutable.
        using var native = new NativeSpline(path, transform.localToWorldMatrix);
    }
}
