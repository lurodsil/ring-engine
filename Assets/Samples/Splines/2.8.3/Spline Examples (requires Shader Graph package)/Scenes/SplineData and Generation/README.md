# SplineData and Generation sample

The SplineData and Generation sample is a complex sample that uses the `SplineData`, `SplineUtility`, and `SplineEditorUtility` APIs to procedurally generate various spline-based objects in the scene.

To see object generation along a spline that leverages the `SplineUtility.GetPointAtLinearDistance` function, select either the **FenceSpline** or **EvenlySpawnSpline** GameObject and manipulate its spline.

`SplineDataHandles` can be used to customize a road's width and a follower's animation parameters in the Editor. To see `SplineDataHandles` in use, select either the **Road Spline** or **Spline Follower** GameObject and then activate the associated `EditorTool`.

Refer to the `AnimateCarAlongSpline.cs` example script to see how to use the `SplineUtility` and `SplineData` APIs to implement a spline.

Play the SplineData and Generation sample scene to see the `AnimateCarAlongSpline.cs` script in use.
