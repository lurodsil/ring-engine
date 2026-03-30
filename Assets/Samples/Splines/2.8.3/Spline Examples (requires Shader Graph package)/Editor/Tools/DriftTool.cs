using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Splines;

using Interpolators = UnityEngine.Splines.Interpolators;

namespace Unity.Splines.Examples
{
    [EditorTool("Drift Tool", typeof(DriftSplineData))]
    public class DriftTool : SplineDataToolBase<float>, IDrawSelectedHandles
    {
        float m_DisplaySpace = 0.2f;
        List<Vector3> m_LineSegments = new List<Vector3>();

        GUIContent m_IconContent;
        public override GUIContent toolbarIcon => m_IconContent;

        bool m_DriftInUse;

        void OnEnable()
        {
            m_IconContent = new GUIContent()
            {
                image = Resources.Load<Texture2D>("Icons/DriftTool"),
                text = "Drift Tool",
                tooltip = "Adjust how much the vehicle is drifting away from the spline."
            };
        }

        public override void OnToolGUI(EditorWindow window)
        {
            var splineDataTarget = target as DriftSplineData;

            if (splineDataTarget == null || splineDataTarget.Container == null)
                return;

            Undo.RecordObject(splineDataTarget, "Modifying Drift SplineData");
            var nativeSpline = new NativeSpline(splineDataTarget.Container.Spline, splineDataTarget.Container.transform.localToWorldMatrix);

            Handles.color = Color.green;

            //User defined : Handles to manipulate Drift data
            m_DriftInUse = DrawDataPoints(nativeSpline, splineDataTarget.Drift);
            //Use defined : Draws a line along the whole Drift SplineData
            DrawSplineData(nativeSpline, splineDataTarget.Drift);

            //Using the out-of the box behaviour to manipulate SplineData indexes
            nativeSpline.DataPointHandles(splineDataTarget.Drift);
        }

        public void OnDrawHandles()
        {
            var splineDataTarget = target as DriftSplineData;
            if (ToolManager.IsActiveTool(this) || splineDataTarget.Container == null)
                return;

            if (Event.current.type != EventType.Repaint)
                return;

            var nativeSpline = new NativeSpline(splineDataTarget.Container.Spline, splineDataTarget.Container.transform.localToWorldMatrix);

            Color color = Color.green;
            color.a = 0.5f;
            Handles.color = color;
            DrawSplineData(nativeSpline, splineDataTarget.Drift);
        }

        protected override bool DrawDataPoint(
            Vector3 position,
            Vector3 tangent,
            Vector3 up,
            float inValue,
            out float outValue)
        {
            outValue = 0f;
            if (tangent == Vector3.zero)
                return false;

            var controlID = GUIUtility.GetControlID(FocusType.Passive);

            var handleColor = Handles.color;
            if (GUIUtility.hotControl == controlID)
                handleColor = Handles.selectedColor;
            else if (GUIUtility.hotControl == 0 && HandleUtility.nearestControl == controlID)
                handleColor = Handles.preselectionColor;

            var right = math.normalize(math.cross(up, tangent));
            var extremity = position + inValue * (Vector3)right;

            using (new Handles.DrawingScope(handleColor))
            {
                var size = 1.5f * k_HandleSize * HandleUtility.GetHandleSize(position);
                Handles.DrawLine(position, extremity);
                var val = Handles.Slider(
                    controlID,
                    extremity,
                    inValue == 0 ? right : right * math.sign(inValue),
                    size,
                    Handles.ConeHandleCap,
                    0);
                Handles.Label(extremity + 2f * size * Vector3.up, inValue.ToString());

                if (GUIUtility.hotControl == controlID)
                {
                    outValue = (val - position).magnitude * math.sign(math.dot(val - position, right));
                    return true;
                }
            }
            return false;
        }

        void DrawSplineData(NativeSpline spline, SplineData<float> splineData)
        {
            m_LineSegments.Clear();
            if (GUIUtility.hotControl == 0
                || m_DriftInUse
                || !ToolManager.IsActiveTool(this)
                || Tools.viewToolActive)
            {
                var data = splineData.Evaluate(spline, 0, PathIndexUnit.Distance, new Interpolators.LerpFloat());
                spline.Evaluate(0, out var position, out var direction, out var upDirection);

                var right = math.normalize(math.cross(upDirection, direction));
                var previousExtremity = (Vector3)position + data * (Vector3)right;

                var currentOffset = m_DisplaySpace;
                while (currentOffset < spline.GetLength())
                {
                    var t = currentOffset / spline.GetLength();
                    spline.Evaluate(t, out position, out direction, out upDirection);

                    right = math.normalize(math.cross(upDirection, direction));

                    data = splineData.Evaluate(spline, currentOffset, PathIndexUnit.Distance, new Interpolators.LerpFloat());

                    var extremity = (Vector3)position + data * (Vector3)right;

                    m_LineSegments.Add(previousExtremity);
                    m_LineSegments.Add(extremity);

                    currentOffset += m_DisplaySpace;
                    previousExtremity = extremity;
                }

                spline.Evaluate(1, out position, out direction, out upDirection);

                right = math.normalize(math.cross(upDirection, direction));
                data = splineData.Evaluate(spline, 1f, PathIndexUnit.Normalized, new Interpolators.LerpFloat());

                var lastExtremity = (Vector3)position + data * (Vector3)right;

                m_LineSegments.Add(previousExtremity);
                m_LineSegments.Add(lastExtremity);
            }
            Handles.DrawLines(m_LineSegments.ToArray());
        }
    }
}
