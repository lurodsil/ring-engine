using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Splines;
using System.Collections.Generic;

[Overlay(typeof(SceneView), "Sonic Spline Tools")]
[Icon("Assets/Extensions/StageEditor/Icons/sonic-icon.png")]
public class SplineOverlay : Overlay
{
    private float distance = 1f;
    private float offset = 1f;
    private float height = 1f;
    private Vector3 loopOffset = new Vector3(5, 5, 1);

    public override VisualElement CreatePanelContent()
    {
        var root = CreateRoot();

        root.Add(CreateDistanceRow());
        root.Add(Spacer());

        root.Add(CreateHeightRow());
        root.Add(Spacer());

        root.Add(CreateLoopRow());
        root.Add(Spacer());

        root.Add(CreateCurveRow());
        root.Add(Spacer());
        root.Add(Divider());

        root.Add(CreateCorkscrewRow());

        root.Add(Duplicate());
      

        return root;
    }

    // =========================
    // 🔹 ROWS
    // =========================

    private VisualElement CreateDistanceRow()
    {
        var row = CreateRow();

        var distanceLabel = new Label("Distance");
        var field = CreateFloatField(distance, 60);
        field.style.flexGrow = 1;

        var flattenToggle = new Toggle("Flatten");

        var button = new Button(() =>
        {
            var spline = GetSelectedSpline();
            if (spline == null) return;

            // Se quiser usar flatten:
            bool flatten = flattenToggle.value;

            new SplineBuilder(spline).AddPoint(field.value, flatten);
        })
        { text = "Add Point" };

        row.Add(distanceLabel);
        row.Add(field);
        row.Add(flattenToggle);
        row.Add(button);

        return row;
    }

    private VisualElement Duplicate()
    {
        var row = CreateRow();

        var field = CreateFloatField(offset, 60);

        var button = new Button(() =>
        {
            var spline = GetSelectedSpline();
            if (spline == null) return;

            new SplineBuilder(spline).DuplicateToLeft(field.value);
        })
        { text = "duplicate" };

        row.Add(button);
        row.Add(new Label("Offset"));
        row.Add(field);

        return row;
    }

    private VisualElement CreateHeightRow()
    {
        var row = CreateRow();

        var field = CreateFloatField(height, 60);

        var button = new Button(() =>
        {
            var spline = GetSelectedSpline();
            if (spline == null) return;

            new SplineBuilder(spline).AddWall(field.value);
        })
        { text = "Add Wall" };

        row.Add(button);
        row.Add(new Label("Height"));
        row.Add(field);

        return row;
    }

    private VisualElement CreateLoopRow()
    {
        var row = CreateRow();

        var xField = CreateFloatField(loopOffset.x, 45);
        var yField = CreateFloatField(loopOffset.y, 45);
        var zField = CreateFloatField(loopOffset.z, 45);

        var button = new Button(() =>
        {
            var spline = GetSelectedSpline();
            if (spline == null) return;

            var offset = new Vector3(
                xField.value,
                yField.value,
                zField.value
            );

            new SplineBuilder(spline).AddLoop(offset, 10,1 );
        })
        { text = "Add Loop" };

        row.Add(button);
        row.Add(new Label("X"));
        row.Add(xField);
        row.Add(new Label("Y"));
        row.Add(yField);
        row.Add(new Label("Z"));
        row.Add(zField);

        return row;
    }

    private VisualElement CreateCorkscrewRow()
    {
        var row = CreateRow();

        // =========================
        // 🔹 OFFSET (X Y Z)
        // =========================
        var xField = CreateFloatField(0f, 45);
        var yField = CreateFloatField(0f, 45);
        var zField = CreateFloatField(0f, 45);

        // =========================
        // 🔹 TURNS (ComboBox)
        // =========================
        var turnOptions = new List<int> { 1, 2, 3, 4, 5 };

        var turnsField = new PopupField<int>(turnOptions, 0);
        turnsField.style.width = 60;

        turnsField.formatListItemCallback = (x) => $"{x}x";
        turnsField.formatSelectedValueCallback = (x) => $"{x}x";

        // =========================
        // 🔹 BUTTON
        // =========================
        var button = new Button(() =>
        {
            var spline = GetSelectedSpline();
            if (spline == null) return;

            var offset = new Vector3(
                xField.value,
                yField.value,
                zField.value
            );

            int turns = turnsField.value;

            new SplineBuilder(spline).AddCorkscrew(offset, 10, turns, 1);
        })
        { text = "Add Corkscrew" };

        // =========================
        // 🔹 LAYOUT
        // =========================
        row.Add(button);

        row.Add(new Label("X"));
        row.Add(xField);

        row.Add(new Label("Y"));
        row.Add(yField);

        row.Add(new Label("Z"));
        row.Add(zField);

        row.Add(new Label("Turns"));
        row.Add(turnsField);

        return row;
    }

    private VisualElement CreateCurveRow()
    {
        var row = CreateRow();

        // =========================
        // 🔹 ANGLE (ComboBox)
        // =========================
        var angleOptions = new List<int> { 15, 30, 45, 60, 90 };

        var angleField = new PopupField<int>(angleOptions, 0);
        angleField.style.width = 70;

        // Exibir com "°"
        angleField.formatListItemCallback = (x) => $"{x}°";
        angleField.formatSelectedValueCallback = (x) => $"{x}°";

        // =========================
        // 🔹 DIRECTION (Enum Combo)
        // =========================
        var directionField = new EnumField(CurveDirection.Right);
        directionField.style.width = 90;

        // =========================
        // 🔹 BUTTON
        // =========================
        var button = new Button(() =>
        {
            var spline = GetSelectedSpline();
            if (spline == null) return;

            float angle = angleField.value;
            var direction = (CurveDirection)directionField.value;

            new SplineBuilder(spline).AddCurve(angle, direction, 3, 10, 1f);
        })
        { text = "Add Curve" };

        // =========================
        // 🔹 LAYOUT
        // =========================
        row.Add(button);
        row.Add(new Label("Angle"));
        row.Add(angleField);
        row.Add(directionField);

        return row;
    }



    // =========================
    // 🔧 HELPERS
    // =========================

    private SplineContainer GetSelectedSpline()
    {
        var go = Selection.activeGameObject;
        if (go == null) return null;

        return go.GetComponent<SplineContainer>();
    }

    private VisualElement CreateRoot()
    {
        var root = new VisualElement();

        root.style.paddingLeft = 6;
        root.style.paddingRight = 6;
        root.style.paddingTop = 6;
        root.style.paddingBottom = 6;

        return root;
    }

    private VisualElement CreateRow()
    {
        var row = new VisualElement();
        row.style.flexDirection = FlexDirection.Row;
        row.style.alignItems = Align.Center;
        row.style.marginBottom = 2;
        return row;
    }

    private FloatField CreateFloatField(float value, float width)
    {
        var field = new FloatField { value = value };
        field.style.width = width;
        return field;
    }

    private VisualElement Spacer()
    {
        return new VisualElement { style = { height = 2 } };
    }

    private VisualElement Divider()
    {
        var divider = new VisualElement();

        divider.style.height = 2;
        divider.style.backgroundColor = Color.gray;
        divider.style.marginLeft = 8;
        divider.style.marginRight = 8;
        divider.style.marginTop = 6;
        divider.style.marginBottom = 6;

        return divider;
    }
}