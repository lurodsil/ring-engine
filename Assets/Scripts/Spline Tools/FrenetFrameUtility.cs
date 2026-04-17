using Unity.Mathematics;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class FrenetFrameUtility
{
    public static FrenetFrame LocalToWorld(FrenetFrame frame, Transform transform)
    {
        return new FrenetFrame(
            (float3)transform.TransformPoint(frame.point),
            math.normalize((float3)transform.TransformDirection(frame.tangent)),
            math.normalize((float3)transform.TransformDirection(frame.normal)),
            frame.t
        );
    }

    public static FrenetFrame WorldToLocal(FrenetFrame frame, Transform transform)
    {
        return new FrenetFrame(
            (float3)transform.InverseTransformPoint(frame.point),
            math.normalize((float3)transform.InverseTransformDirection(frame.tangent)),
            math.normalize((float3)transform.InverseTransformDirection(frame.normal)),
            frame.t
        );
    }

#if UNITY_EDITOR
    public static void DrawFrame(FrenetFrame frenetFrame)
    {
        Handles.color = Color.blue;
        Handles.ArrowHandleCap(0, frenetFrame.point, Quaternion.LookRotation(frenetFrame.tangent, frenetFrame.normal), 1f, EventType.Repaint);

        Handles.color = Color.green;
        Handles.ArrowHandleCap(0, frenetFrame.point, Quaternion.LookRotation(frenetFrame.normal, frenetFrame.binormal), 1f, EventType.Repaint);

        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, frenetFrame.point, Quaternion.LookRotation(frenetFrame.binormal, frenetFrame.normal), 1f, EventType.Repaint);
    }
#endif
}