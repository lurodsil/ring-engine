using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConvertToDualBezierSpline))]
public class ConvertToDualBezierSplineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ConvertToDualBezierSpline convertToDualBezierSpline = (ConvertToDualBezierSpline)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Convert"))
        {
            convertToDualBezierSpline.Convert();
        }
    }
}
