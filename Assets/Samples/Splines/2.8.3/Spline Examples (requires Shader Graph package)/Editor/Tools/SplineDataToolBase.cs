using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    public abstract class SplineDataToolBase<DataType> : EditorTool
    {
        protected const float k_HandleSize = 0.15f;

        protected bool DrawDataPoints(ISpline spline, SplineData<DataType> splineData)
        {
            var inUse = false;
            for (int dataFrameIndex = 0; dataFrameIndex < splineData.Count; dataFrameIndex++)
            {
                var dataPoint = splineData[dataFrameIndex];

                var normalizedT = SplineUtility.GetNormalizedInterpolation(spline, dataPoint.Index, splineData.PathIndexUnit);
                spline.Evaluate(normalizedT, out var position, out var tangent, out var up);

                if (DrawDataPoint(position, tangent, up, dataPoint.Value, out var result))
                {
                    dataPoint.Value = result;
                    splineData[dataFrameIndex] = dataPoint;
                    inUse = true;
                }
            }
            return inUse;
        }

        /// <summary>
        /// User defined method, for simplicity here, all the SplineData Tools have to override the same DrawDataPoint method for consistency between tools
        /// </summary>
        /// <param name="position"></param>
        /// <param name="tangent"></param>
        /// <param name="up"></param>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        /// <returns>True if the dataPoint is manipulated, else false.</returns>
        protected abstract bool DrawDataPoint(
            Vector3 position,
            Vector3 tangent,
            Vector3 up,
            DataType inValue,
            out DataType outValue);
    }
}
