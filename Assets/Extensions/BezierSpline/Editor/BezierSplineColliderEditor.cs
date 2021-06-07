using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierSplineCollider))]
public class BezierSplineColliderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BezierSplineCollider bezierSplineCollider = (BezierSplineCollider)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create Collider"))
        {
            bezierSplineCollider.CreateMesh(bezierSplineCollider.iterations);
        }

        if (GUILayout.Button("Erase Collider"))
        {
            bezierSplineCollider.EraseMesh();
        }
    }
}