using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DualBezierSplineCollider))]
public class DualBezierSplineColliderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DualBezierSplineCollider dualBezierSplineCollider = (DualBezierSplineCollider)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create Collider"))
        {
            dualBezierSplineCollider.CreateMesh(dualBezierSplineCollider.iterations);
        }

        if (GUILayout.Button("Erase Collider"))
        {
            dualBezierSplineCollider.EraseMesh();
        }
    }
}