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
            CreateOrPopulateObjects(bezierObjectPlacer, 1, false);
        }

        if (GUILayout.Button("Populate Spline"))
        {
            CreateOrPopulateObjects(bezierObjectPlacer, bezierObjectPlacer.objectsAlongSpline, true);
        }
    }

    private void CreateOrPopulateObjects(BezierObjectPlacer bezierObjectPlacer, float stepCount, bool isPopulating)
    {
        float step = 1 / stepCount;

        for (float t = 0; t < 1; t += step)
        {
            BezierKnot bezierKnot = GetBezierKnot(bezierObjectPlacer, isPopulating ? t : bezierObjectPlacer.time);

            if (bezierKnot != null)
            {
                Vector3 position = bezierKnot.point +
                    (bezierKnot.binormal * bezierObjectPlacer.offset.x) +
                    (bezierKnot.normal * bezierObjectPlacer.offset.y) +
                    (bezierKnot.tangent * bezierObjectPlacer.offset.z);

                Quaternion rotation = Quaternion.LookRotation(bezierKnot.tangent, bezierKnot.normal);

                Instantiate(bezierObjectPlacer.prefab, position, rotation);
            }

            if (!isPopulating) break; // Exit the loop if we are only creating a single object
        }
    }

    private BezierKnot GetBezierKnot(BezierObjectPlacer bezierObjectPlacer, float time)
    {
        if (bezierObjectPlacer.bezierSpline != null)
        {
            return bezierObjectPlacer.bezierSpline.GetKnot(time);
        }
        else if (bezierObjectPlacer.dualBezierSpline != null)
        {
            return bezierObjectPlacer.dualBezierSpline.GetKnot(time, 0.5f);
        }
        return null;
    }
}
