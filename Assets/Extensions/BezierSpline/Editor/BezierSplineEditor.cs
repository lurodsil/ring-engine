using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierSpline))]
public class BezierSplineEditor : Editor
{
    private int selectedIndex = 0;
    private int selectedVector = -1;
    private BezierSpline bezierSpline;
    private const float handleSize = 0.2f;
    private const float pickSize = 0.4f;

    public override void OnInspectorGUI()
    {
        bezierSpline = target as BezierSpline;

        EditorGUI.BeginChangeCheck();
        BezierControlPointMode mode = (BezierControlPointMode)EditorGUILayout.EnumPopup("Control Point Mode", bezierSpline.bezierControlPoints[selectedIndex].bezierControlPointMode);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(bezierSpline, "Change Control Point Mode");
            bezierSpline.bezierControlPoints[selectedIndex].bezierControlPointMode = mode;
            EditorUtility.SetDirty(bezierSpline);
        }

        if (GUILayout.Button("Add Control Point"))
        {
            BezierControlPoint lastControlPoint = bezierSpline.bezierControlPoints[bezierSpline.bezierControlPoints.Count - 1];

            Vector3 lastDirection = (lastControlPoint.point - lastControlPoint.invec).normalized;

            bezierSpline.bezierControlPoints.Add(new BezierControlPoint(lastControlPoint.point + (lastDirection * 2), lastControlPoint.point + (lastDirection), lastControlPoint.point + (lastDirection * 3), lastControlPoint.bezierControlPointMode));

            SceneView.RepaintAll();

            selectedIndex = bezierSpline.bezierControlPoints.Count - 1;

            selectedVector = -1;
        }

        if (GUILayout.Button("Remove Control Point"))
        {
            Undo.RecordObject(bezierSpline, "Remove Control Point");

            bezierSpline.bezierControlPoints.RemoveAt(selectedIndex);

            SceneView.RepaintAll();

            selectedIndex--;

            selectedVector = -1;

            EditorUtility.SetDirty(bezierSpline);
        }

        Repaint();

        //Draw Options
        EditorGUI.BeginChangeCheck();
        bezierSpline.alwaysDrawSpline = EditorGUILayout.Toggle("Always Draw Spline", bezierSpline.alwaysDrawSpline);
        bool drawDirections = EditorGUILayout.Toggle("Draw Directions", bezierSpline.drawDirections);
        if (drawDirections)
        {
            bezierSpline.drawPrecision = EditorGUILayout.Slider("Precision", bezierSpline.drawPrecision, 0.1f, 0.001f);
        }
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(bezierSpline, "Change Draw Tangents");
            bezierSpline.drawDirections = drawDirections;
            SceneView.RepaintAll();
            EditorUtility.SetDirty(bezierSpline);
        }
    }

    private void OnSceneGUI()
    {
        bezierSpline = target as BezierSpline;

        if (bezierSpline.bezierControlPoints.Count > 1)
        {
            Handles.color = Color.white;
            for (int i = 0; i < bezierSpline.bezierControlPoints.Count; i++)
            {
                if (Handles.Button(bezierSpline.transform.TransformPoint(bezierSpline.bezierControlPoints[i].point), Quaternion.identity, handleSize, pickSize, Handles.DotHandleCap))
                {
                    selectedIndex = i;
                    selectedVector = -1;
                }
            }

            BezierControlPoint bezierControlPoint = bezierSpline.bezierControlPoints[selectedIndex];

            Vector3 point = bezierSpline.transform.TransformPoint(bezierControlPoint.point);
            Vector3 invec = bezierSpline.transform.TransformPoint(bezierControlPoint.invec);
            Vector3 outvec = bezierSpline.transform.TransformPoint(bezierControlPoint.outvec);
            Vector3 invecDir = invec - point;
            Vector3 outvecDir = outvec - point;

            if (Handles.Button(invec, Quaternion.identity, handleSize, pickSize, Handles.DotHandleCap))
            {
                selectedVector = 0;
            }

            if (Handles.Button(outvec, Quaternion.identity, handleSize, pickSize, Handles.DotHandleCap))
            {
                selectedVector = 1;
            }

            switch (selectedVector)
            {
                case 0:
                    EditorGUI.BeginChangeCheck();
                    invec = Handles.DoPositionHandle(invec, Quaternion.identity);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(bezierSpline, "Change Invec Position");
                        EditorUtility.SetDirty(bezierSpline);
                    }

                    switch (bezierControlPoint.bezierControlPointMode)
                    {
                        case BezierControlPointMode.Free:
                            break;
                        case BezierControlPointMode.Aligned:
                            outvec = point - (invecDir.normalized * outvecDir.magnitude);
                            break;
                        case BezierControlPointMode.Mirrored:
                            outvec = point - invecDir;
                            break;
                    }

                    break;
                case 1:
                    EditorGUI.BeginChangeCheck();
                    outvec = Handles.DoPositionHandle(outvec, Quaternion.identity);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(bezierSpline, "Change Outvec Position");
                        EditorUtility.SetDirty(bezierSpline);
                    }

                    switch (bezierControlPoint.bezierControlPointMode)
                    {
                        case BezierControlPointMode.Free:
                            break;
                        case BezierControlPointMode.Aligned:
                            invec = point - (outvecDir.normalized * invecDir.magnitude);
                            break;
                        case BezierControlPointMode.Mirrored:
                            invec = point - outvecDir;
                            break;
                    }
                    break;
                default:
                    EditorGUI.BeginChangeCheck();
                    point = Handles.DoPositionHandle(point, Quaternion.identity);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(bezierSpline, "Change Point Position");
                        EditorUtility.SetDirty(bezierSpline);
                    }
                    invec = point + invecDir;
                    outvec = point + outvecDir;
                    break;
            }

            bezierControlPoint.point = bezierSpline.transform.InverseTransformPoint(point);
            bezierControlPoint.invec = bezierSpline.transform.InverseTransformPoint(invec);
            bezierControlPoint.outvec = bezierSpline.transform.InverseTransformPoint(outvec);

            bezierSpline.bezierControlPoints[selectedIndex] = bezierControlPoint;

            //Draw Lines
            Handles.color = Color.green;
            Handles.DrawLine(point, invec);
            Handles.DrawLine(point, outvec);
        }
    }
}
