using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierObjectPlacer))]
public class BezierObjectPlacerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BezierObjectPlacer bezierObjectPlacer = (BezierObjectPlacer)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create Object"))
        {
            BezierKnot bezierKnot = bezierObjectPlacer.dualBezierSpline.GetKnot(bezierObjectPlacer.time, 0.5f);

            Instantiate(bezierObjectPlacer.prefab, bezierKnot.point + 
                (bezierKnot.binormal * bezierObjectPlacer.offset.x) +
                (bezierKnot.normal * bezierObjectPlacer.offset.y) +
                (bezierKnot.tangent * bezierObjectPlacer.offset.z),
                Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal));
        }
    }
}