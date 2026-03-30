using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Splines;
#if UNITY_2022_1_OR_NEWER
using UnityEditor.Overlays;
#else
using System.Reflection;
using UnityEditor.Toolbars;
using UnityEngine.UIElements;
#endif

using Interpolators = UnityEngine.Splines.Interpolators;

namespace Unity.Splines.Examples
{
    [CustomEditor(typeof(SpeedTiltTool))]
#if UNITY_2022_1_OR_NEWER
    class SplineDataPointToolSettings : UnityEditor.Editor, ICreateToolbar
#else
    class SplineDataPointToolSettings : UnityEditor.Editor
#endif
    {
        public virtual IEnumerable<string> toolbarElements
        {
            get
            {
                yield return "Tool Settings/Pivot Mode";
                yield return "Tool Settings/Pivot Rotation";
                yield return "SpeedTiltTool/SplineDataType";
            }
        }

#if !UNITY_2022_1_OR_NEWER
        const string k_ElementClassName = "unity-editor-toolbar-element";
        const string k_StyleSheetsPath = "StyleSheets/Toolbars/";

        static VisualElement CreateToolbar()
        {
            var target = new VisualElement();
            var path = k_StyleSheetsPath + "EditorToolbar";

            var common = EditorGUIUtility.Load($"{path}Common.uss") as StyleSheet;
            if (common != null)
                target.styleSheets.Add(common);

            var themeSpecificName = EditorGUIUtility.isProSkin ? "Dark" : "Light";
            var themeSpecific = EditorGUIUtility.Load($"{path}{themeSpecificName}.uss") as StyleSheet;
            if (themeSpecific != null)
                target.styleSheets.Add(themeSpecific);

            target.AddToClassList("unity-toolbar-overlay");
            target.style.flexDirection = FlexDirection.Row;
            return target;
        }

        public override VisualElement CreateInspectorGUI()
        {
            var root = CreateToolbar();

            var elements = TypeCache.GetTypesWithAttribute(typeof(EditorToolbarElementAttribute));

            foreach (var element in toolbarElements)
            {
                var type = elements.FirstOrDefault(x =>
                {
                    var attrib = x.GetCustomAttribute<EditorToolbarElementAttribute>();
                    return attrib != null && attrib.id == element;
                });

                if (type != null)
                {
                    try
                    {
                        const BindingFlags flags =  BindingFlags.Instance |
                            BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.CreateInstance;

                        var ve = (VisualElement)Activator.CreateInstance(type, flags, null, null, null, null);
                        ve.AddToClassList(k_ElementClassName);
                        root.Add(ve);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Failed creating toolbar element from ID \"{element}\".\n{e}");
                    }
                }
            }

            EditorToolbarUtility.SetupChildrenAsButtonStrip(root);

            return root;
        }

#endif
    }

    [EditorTool("Speed & Tilt Tool", typeof(AnimateCarAlongSpline))]
    public class SpeedTiltTool : EditorTool, IDrawSelectedHandles
    {
        internal enum SplineDataType
        {
            SpeedData,
            TiltData
        };

        //Speed handles parameters
        const float k_SpeedScaleFactor = 10f;
        const float k_DisplaySpace = 0.5f;

        //Tilt handles parameters
        Quaternion m_StartingRotation;

        const float k_HandleSize = 0.15f;

        Color[] m_HandlesColors = {Color.red, new(1f, 0.6f, 0f)};
        List<Vector3> m_LineSegments = new List<Vector3>();
        static SplineDataType s_SelectedSplineData = SplineDataType.SpeedData;
        internal static SplineDataType selectedSplineData
        {
            get => s_SelectedSplineData;
            set => s_SelectedSplineData = value;
        }

        GUIContent m_IconContent;
        public override GUIContent toolbarIcon => m_IconContent;

        bool m_DisableHandles;
        bool m_SpeedInUse;
        bool m_TiltInUse;

        void OnEnable()
        {
            m_IconContent = new GUIContent()
            {
                image = Resources.Load<Texture2D>("Icons/SpeedTiltTool"),
                text = "Speed & Tilt Tool",
                tooltip = "Adjust the vehicle speed and tilt DataPoints along the spline."
            };
        }

        public override void OnToolGUI(EditorWindow window)
        {
            var splineDataTarget = target as AnimateCarAlongSpline;
            if (splineDataTarget == null || splineDataTarget.Container == null)
                return;

            var nativeSpline = new NativeSpline(splineDataTarget.Container.Spline, splineDataTarget.Container.transform.localToWorldMatrix);

            Undo.RecordObject(splineDataTarget, "Modifying Speed and Tilt SplineData");

            m_DisableHandles = false;

            //Speed handles section
            Handles.color = m_HandlesColors[(int)SplineDataType.SpeedData];
            //User defined : Handles to manipulate Speed data
            m_SpeedInUse = DrawSpeedDataPoints(nativeSpline, splineDataTarget.Speed, splineDataTarget.MaxSpeed, true);
            //Use defined : Draws a line along the whole Speed SplineData
            DrawSpeedSplineData(nativeSpline, splineDataTarget.Speed);

            //Tilt handles section
            Handles.color = m_HandlesColors[(int)SplineDataType.TiltData];
            //User defined : Handles to manipulate Tilt data
            m_TiltInUse = DrawTiltDataPoints(nativeSpline, splineDataTarget.Tilt);
            //Use defined : Draws a line along the whole Tilt SplineData
            DrawTiltSplineData(nativeSpline, splineDataTarget.Tilt);

            //Draw DataPoint default Manipulation handles
            Handles.color = m_HandlesColors[(int)s_SelectedSplineData];
            if (s_SelectedSplineData == SplineDataType.SpeedData)
                nativeSpline.DataPointHandles(splineDataTarget.Speed);
            else
                nativeSpline.DataPointHandles(splineDataTarget.Tilt);
        }

        public void OnDrawHandles()
        {
            var splineDataTarget = target as AnimateCarAlongSpline;
            if (ToolManager.IsActiveTool(this) || splineDataTarget.Container == null)
                return;

            if (Event.current.type != EventType.Repaint)
                return;

            m_DisableHandles = true;

            var nativeSpline = new NativeSpline(splineDataTarget.Container.Spline, splineDataTarget.Container.transform.localToWorldMatrix);
            Color color = m_HandlesColors[(int)SplineDataType.SpeedData];
            color.a = 0.5f;
            Handles.color = color;
            DrawSpeedDataPoints(nativeSpline, splineDataTarget.Speed, splineDataTarget.MaxSpeed, false);
            DrawSpeedSplineData(nativeSpline, splineDataTarget.Speed);

            color = m_HandlesColors[(int)SplineDataType.TiltData];
            color.a = 0.5f;
            Handles.color = color;
            DrawTiltSplineData(nativeSpline, splineDataTarget.Tilt);
        }

        bool DrawSpeedDataPoints(NativeSpline spline, SplineData<float> speedSplineData, float maxSpeed, bool drawLabel)
        {
            var inUse = false;
            for (int dataFrameIndex = 0; dataFrameIndex < speedSplineData.Count; dataFrameIndex++)
            {
                var dataPoint = speedSplineData[dataFrameIndex];

                var normalizedT = SplineUtility.GetNormalizedInterpolation(spline, dataPoint.Index, speedSplineData.PathIndexUnit);
                var position = spline.EvaluatePosition(normalizedT);

                var speedValue = dataPoint.Value;
                if (speedValue > maxSpeed)
                {
                    speedValue = maxSpeed;
                    dataPoint.Value = maxSpeed;
                    speedSplineData[dataFrameIndex] = dataPoint;
                }

                var id = m_DisableHandles ? -1 : GUIUtility.GetControlID(FocusType.Passive);
                if (DrawSpeedDataPoint(id, position, speedValue, drawLabel, out var result))
                {
                    dataPoint.Value = Mathf.Clamp(result, 0.01f, maxSpeed);
                    speedSplineData[dataFrameIndex] = dataPoint;
                    inUse = true;
                }
            }

            return inUse;
        }

        bool DrawSpeedDataPoint(
            int controlID,
            Vector3 position,
            float inValue,
            bool drawLabel,
            out float outValue)
        {
            outValue = 0f;
            var handleColor = Handles.color;
            if (GUIUtility.hotControl == controlID)
                handleColor = Handles.selectedColor;
            else if (GUIUtility.hotControl == 0 && HandleUtility.nearestControl == controlID)
                handleColor = Handles.preselectionColor;

            var extremity = position + (inValue / k_SpeedScaleFactor) * Vector3.up;
            using (new Handles.DrawingScope(handleColor))
            {
                var size = k_HandleSize * HandleUtility.GetHandleSize(position);
                Handles.DrawLine(position, extremity);
                var val = Handles.Slider(controlID, extremity, Vector3.up, size, Handles.SphereHandleCap, 0);
                if (drawLabel)
                    Handles.Label(extremity + 2f * size * Vector3.up, inValue.ToString());

                if (GUIUtility.hotControl == controlID)
                {
                    outValue = k_SpeedScaleFactor * (val - position).magnitude * math.sign(math.dot(val - position, Vector3.up));
                    return true;
                }
            }

            return false;
        }

        bool DrawTiltDataPoints(NativeSpline spline, SplineData<float3> tiltSplineData)
        {
            var inUse = false;
            for (int dataFrameIndex = 0; dataFrameIndex < tiltSplineData.Count; dataFrameIndex++)
            {
                var dataPoint = tiltSplineData[dataFrameIndex];

                var normalizedT = SplineUtility.GetNormalizedInterpolation(spline, dataPoint.Index, tiltSplineData.PathIndexUnit);
                spline.Evaluate(normalizedT, out var position, out var tangent, out var up);

                var id = m_DisableHandles ? -1 : GUIUtility.GetControlID(FocusType.Passive);
                if (DrawTiltDataPoint(id, position, tangent, up, dataPoint.Value, out var result))
                {
                    dataPoint.Value = result;
                    tiltSplineData[dataFrameIndex] = dataPoint;
                    inUse = true;
                }
            }
            return inUse;
        }

        bool DrawTiltDataPoint(
            int controlID,
            Vector3 position,
            Vector3 tangent,
            Vector3 up,
            float3 inValue,
            out float3 outValue)
        {
            outValue = float3.zero;
            if (tangent == Vector3.zero)
                return false;

            Matrix4x4 localMatrix = Matrix4x4.identity;
            localMatrix.SetTRS(position, Quaternion.LookRotation(tangent, up), Vector3.one);

            var matrix = Handles.matrix * localMatrix;
            using (new Handles.DrawingScope(matrix))
            {
                var dataPointRotation = Quaternion.FromToRotation(Vector3.up, inValue);

                if (GUIUtility.hotControl == 0)
                    m_StartingRotation = dataPointRotation;

                var color = Handles.color;
                if (!m_TiltInUse)
                    color.a = 0.33f;

                if (Event.current.type == EventType.Repaint)
                {
                    using (new Handles.DrawingScope(color))
                        Handles.ArrowHandleCap(-1, Vector3.zero, Quaternion.FromToRotation(Vector3.forward, inValue), 1f, EventType.Repaint);
                }

                var rotation = Handles.Disc(controlID, dataPointRotation, Vector3.zero, Vector3.forward, 1, false, 0);

                if (GUIUtility.hotControl == controlID)
                {
                    var deltaRot = Quaternion.Inverse(m_StartingRotation) * rotation;
                    outValue = deltaRot * m_StartingRotation * Vector3.up;
                    return true;
                }
            }

            return false;
        }

        void DrawSpeedSplineData(NativeSpline spline, SplineData<float> splineData)
        {
            m_LineSegments.Clear();
            if (GUIUtility.hotControl == 0
                || m_SpeedInUse
                || !ToolManager.IsActiveTool(this)
                || Tools.viewToolActive)
            {
                var data = splineData.Evaluate(spline, 0, PathIndexUnit.Distance, new Interpolators.LerpFloat());
                var position = spline.EvaluatePosition(0);
                var previousExtremity = (Vector3)position + (data / k_SpeedScaleFactor) * Vector3.up;

                var currentOffset = k_DisplaySpace;
                while (currentOffset < spline.GetLength())
                {
                    var t = currentOffset / spline.GetLength();
                    position = spline.EvaluatePosition(t);
                    data = splineData.Evaluate(spline, currentOffset, PathIndexUnit.Distance, new Interpolators.LerpFloat());

                    var extremity = (Vector3)position + (data / k_SpeedScaleFactor) * Vector3.up;

                    m_LineSegments.Add(previousExtremity);
                    m_LineSegments.Add(extremity);

                    currentOffset += k_DisplaySpace;
                    previousExtremity = extremity;
                }

                position = spline.EvaluatePosition(1);
                data = splineData.Evaluate(spline, spline.GetLength(), PathIndexUnit.Distance, new Interpolators.LerpFloat());

                var lastExtremity = (Vector3)position + (data / k_SpeedScaleFactor) * Vector3.up;

                m_LineSegments.Add(previousExtremity);
                m_LineSegments.Add(lastExtremity);
            }
            Handles.DrawLines(m_LineSegments.ToArray());
        }

        void DrawTiltSplineData(NativeSpline spline, SplineData<float3> splineData)
        {
            m_LineSegments.Clear();
            if (GUIUtility.hotControl == 0
                || m_TiltInUse
                || !ToolManager.IsActiveTool(this)
                || Tools.viewToolActive)
            {
                var currentOffset = k_DisplaySpace;
                while (currentOffset < spline.GetLength())
                {
                    var t = currentOffset / spline.GetLength();
                    spline.Evaluate(t, out float3 position, out float3 direction, out float3 up);
                    var data = splineData.Evaluate(spline, t, PathIndexUnit.Normalized,
                        new Interpolators.LerpFloat3());

                    Matrix4x4 localMatrix = Matrix4x4.identity;
                    localMatrix.SetTRS(position, Quaternion.LookRotation(direction, up), Vector3.one);
                    m_LineSegments.Add(localMatrix.GetPosition());
                    m_LineSegments.Add(localMatrix.MultiplyPoint(math.normalize(data)));

                    currentOffset += k_DisplaySpace;
                }
            }

            var color = Handles.color;
            if (!m_TiltInUse)
                color.a = 0.33f;

            using (new Handles.DrawingScope(color))
                Handles.DrawLines(m_LineSegments.ToArray());
        }
    }
}
