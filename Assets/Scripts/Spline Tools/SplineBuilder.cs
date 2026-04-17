using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Splines;
using UnityEngine.SocialPlatforms;
using UnityEngine.Splines;
using UnityEngine.Splines.Extensions;

public class SplineBuilder
{
    private SplineContainer splineContainer { get; set; }

    public SplineBuilder(SplineContainer splineContainer)
    {
        this.splineContainer = splineContainer;
    }

    private void SelecIndex(int splineIndex, int knotIndex)
    {
        SplineSelection.Clear();

        var info = new SplineInfo(splineContainer, splineIndex);
        var knot = new SelectableKnot(info, knotIndex);

        SplineSelection.Set(knot);
    }

    public void AddPoint(float distance, bool flatten = true)
    {
        var spline = splineContainer.Splines[0];
        if (spline.Count == 0) return;
        Undo.RecordObject(splineContainer, "Add Point");


        spline.Evaluate(1, out float3 position, out float3 tangent, out _);

        if (flatten)
        {
            tangent.y = 0;
        }

        spline.Add(new UnityEngine.Splines.BezierKnot(position + math.normalize(tangent) * distance));

        int i = spline.Count - 1;

        spline.SetTangentMode(i, TangentMode.AutoSmooth);

        EditorUtility.SetDirty(splineContainer);


        SelecIndex(0, spline.Count - 1);
    }

    public void AddWall(float height)
    {
        var spline = splineContainer.Splines[0];
        if (spline.Count == 0) return;

        Undo.RecordObject(splineContainer, "Add Wall");

        spline.Evaluate(1, out float3 position, out float3 tangent, out float3 up);

        float3 forward = math.normalize(tangent);
        float3 normalUp = new float3(0, 1f, 0);

        quaternion rot = quaternion.LookRotationSafe(forward, normalUp);

        // --- PONTO A (último ponto existente)
        int i1 = spline.Count - 1;
        var knotA = spline[i1];


        knotA.TangentIn.z = -0.01f;
        knotA.TangentOut.z = 0.01f;
        spline.SetTangentMode(i1, TangentMode.Broken);
        spline[i1] = knotA;


        float3 posA = position;

        // --- PONTO B (sobe)
        float3 posB = posA + normalUp * height;

        var knotB = new UnityEngine.Splines.BezierKnot(posB, default, default, rot);

        knotB.TangentIn.z = -0.01f;
        knotB.TangentOut.z = 0.01f;

        spline.Add(knotB);

        int i2 = spline.Count - 1;
        spline.SetTangentMode(i2, TangentMode.Broken);

        // 🔥 mantém movimento pra frente (plano horizontal opcional)
        forward.y = 0;
        forward = math.normalize(forward);

        float3 posC = posB + forward * 1f;

        // --- PONTO C (suave)
        spline.Add(new UnityEngine.Splines.BezierKnot(posC, default, default, rot));
        int i3 = spline.Count - 1;
        spline.SetTangentMode(i3, TangentMode.AutoSmooth);

        EditorUtility.SetDirty(splineContainer);

        SelecIndex(0, i3);
    }

    public void DuplicateToLeft(float offset)
    {
        var container = splineContainer;

        int index;

        //container.DuplicateSpline(container.Splines[0], container.Splines[container.Splines.Count - 1], out index);
        //container.

        var spline = container.Splines[1];
        if (spline.Count < 2) return;

        var list = new List<SplineInfo>();
        for (int s = 0; s < container.Splines.Count; s++)
            list.Add(new SplineInfo(container, s));

        var element = SplineSelection.GetActiveElement(list);
        if (element == null) return;

        if (element.SplineInfo.Index != 1) return;

        int i = element.KnotIndex;
        if (i < 0 || i >= spline.Count) return;

        Undo.RecordObject(container, "Offset Active Left");

        SplineUtility.GetNearestPoint(spline, element.Position, out float3 _, out float t);

        spline.Evaluate(t, out float3 posEval, out float3 tangent, out float3 up);

        float3 forward = math.normalizesafe(tangent);
        float3 right = math.normalizesafe(math.cross(forward, up));

        float3 offsetVec = right * offset;

        var knot = spline[i];
        knot.Position += offsetVec;

        spline[i] = knot;

        EditorUtility.SetDirty(container);
    }

    public void AddLoop(float3 size, int resolution = 20, int turns = 1, int side = 1)
    {
        var spline = splineContainer.Splines[0];
        if (spline.Count == 0) return;

        Undo.RecordObject(splineContainer, "Add Loop");

        spline.Evaluate(1, out float3 posA, out float3 tangent, out float3 up);

        float3 forward = math.normalize(tangent);
        float3 localUp = math.normalize(up);
        float3 right = math.normalize(math.cross(forward, localUp)) * side;

        int currentIndex = spline.Count - 1;
        spline.SetTangentMode(currentIndex, TangentMode.AutoSmooth);

        float radiusX = size.x * 0.5f;
        float radiusY = size.y * 0.5f;

        float totalLength = size.z * turns;
        float3 center = posA + localUp * radiusY;

        float totalAngle = math.PI * 2f * turns;

        AddLoopSegment(spline, center, forward, localUp, right, radiusX, radiusY, totalLength, resolution * turns, 0f, totalAngle);

        EditorUtility.SetDirty(splineContainer);
        SelecIndex(0, spline.Count - 1);
    }

    public void AddCorkscrew(float3 size, int resolution = 20, int turns = 1, int side = 1)
    {
        var spline = splineContainer.Splines[0];
        if (spline.Count == 0) return;

        Undo.RecordObject(splineContainer, "Add Loop");

        spline.Evaluate(1, out float3 posA, out float3 tangent, out float3 up);

        float3 forward = math.normalize(tangent);
        float3 localUp = math.normalize(up);
        float3 right = math.normalize(math.cross(forward, localUp)) * side; // 🔥 aqui

        int currentIndex = spline.Count - 1;
        spline.SetTangentMode(currentIndex, TangentMode.AutoSmooth);

        float radiusX = size.x * 0.5f;
        float radiusY = size.y * 0.5f;

        float totalLength = size.z * turns;
        float3 center = posA + localUp * radiusY;

        float totalAngle = math.PI * 2f * turns;

        AddLoopSegment(
            spline,
            center,
            right,     // mantém sua lógica original
            localUp,
            forward,
            radiusX,
            radiusY,
            totalLength,
            resolution * turns,
            0f,
            totalAngle
        );

        EditorUtility.SetDirty(splineContainer);
        SelecIndex(0, spline.Count - 1);
    }

    private void AddLoopSegment(Spline spline, float3 center, float3 forward, float3 localUp, float3 right, float radiusX, float radiusY, float length, int resolution, float startAngle, float endAngle)
    {
        float angleRange = endAngle - startAngle;
        float stepZ = length / resolution;

        for (int i = 1; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            float angle = startAngle + angleRange * t;

            float x = math.sin(angle) * radiusX;
            float y = -math.cos(angle) * radiusY;
            float z = stepZ * i;

            float3 pos = center + forward * x + localUp * y + right * z;

            float dx = math.cos(angle) * radiusX;
            float dy = math.sin(angle) * radiusY;

            float3 dir = math.normalize(forward * dx + localUp * dy);

            float3 normal = -math.normalize(forward * x + localUp * y);

            quaternion rot = quaternion.LookRotationSafe(dir, normal);

            spline.AddPoint(pos, TangentMode.AutoSmooth, rot, dir);
        }
    }


    public void AddCurve(
     float angle,
     CurveDirection direction,
     int steps = 5,
     float distancePerStep = 2f,
     float heightOffset = 0f // 👈 novo
 )
    {
        var spline = splineContainer.Splines[0];
        if (spline.Count == 0) return;

        Undo.RecordObject(splineContainer, "Add Curve");

        spline.Evaluate(1, out float3 pos, out float3 tangent, out float3 up);

        float3 forward = math.normalize(tangent);
        float3 normalUp = math.normalize(up);
        float3 right = math.normalize(math.cross(forward, normalUp));

        float3 axis = float3.zero;

        switch (direction)
        {
            case CurveDirection.Left:
                axis = normalUp;
                angle = -angle;
                break;
            case CurveDirection.Right:
                axis = normalUp;
                break;
            case CurveDirection.Up:
                axis = right;
                break;
            case CurveDirection.Down:
                axis = right;
                angle = -angle;
                break;
        }

        float angleStep = math.radians(angle / steps);
        float heightStep = heightOffset / steps; // 👈 distribui altura

        float3 currentPos = pos;
        float3 currentForward = forward;

        for (int i = 0; i < steps; i++)
        {
            quaternion rot = quaternion.AxisAngle(axis, angleStep);
            currentForward = math.normalize(math.mul(rot, currentForward));

            // movimento forward + altura
            currentPos += currentForward * distancePerStep;
            currentPos += normalUp * heightStep; // 👈 offset vertical

            spline.Add(new UnityEngine.Splines.BezierKnot(currentPos));
            spline.SetTangentMode(spline.Count - 1, TangentMode.AutoSmooth);
        }

        EditorUtility.SetDirty(splineContainer);
        SelecIndex(0, spline.Count - 1);
    }

    static void InsertPoint(SplineContainer container, float distance)
    {
        var spline = container.Splines[0];
        if (spline.Count == 0) return;

        var list = new List<SplineInfo>();
        for (int i = 0; i < container.Splines.Count; i++)
            list.Add(new SplineInfo(container, i));

        var element = SplineSelection.GetActiveElement(list);
        int index = element.KnotIndex;

        Undo.RecordObject(container, "Insert Point");

        SplineUtility.GetNearestPoint(spline, element.Position, out float3 nearest, out float t);

        spline.Evaluate(t, out float3 pos, out float3 tan, out _);

        float3 tangent = math.normalize(tan);
        float3 newPos = pos + tangent * distance;

        // ⚠️ Inserir baseado no T, não no índice
        int insertIndex = index + 1;

        // 🔥 Inserir depois do selecionado
        spline.Insert(index, new UnityEngine.Splines.BezierKnot(newPos));

        spline.SetTangentMode(index, TangentMode.AutoSmooth);

        EditorUtility.SetDirty(container);


    }
}

