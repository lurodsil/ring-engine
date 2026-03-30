# GPU Evaluation sample

The GPU Evaluation sample demonstrates how to evaluate splines on a GPU (Graphics Processing Unit).

In the Splines package, `Spline.cginc` can be used to write shaders that work with splines.

Refer to `SplineRendererCompute.cs` to see an example on how to use `SplineComputeBufferScope` to pass spline information to the GPU.

Refer to the `InterpolateSpline.compute` shader to see how to use `Spline.cginc` to evaluate the position of a spline in a computer shader.

Play the GPU Evaluation sample scene to see GPU spline evaluation in action.

