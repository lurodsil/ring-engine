using System.Globalization;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class GenerationsSplineReader : EditorWindow
{
    [SerializeField] private TextAsset[] xmlsToRead;

    private SerializedObject so;
    private SerializedProperty xmlsProp;

    [MenuItem("Window/Ring Engine Tools/Generations Spline Reader")]
    public static void ShowWindow()
    {
        GetWindow<GenerationsSplineReader>("XML Reader");
    }

    private void OnEnable()
    {
        so = new SerializedObject(this);
        xmlsProp = so.FindProperty("xmlsToRead");
    }

    private void OnGUI()
    {
        so.Update();

        EditorGUILayout.PropertyField(xmlsProp, new GUIContent("XML Files"), true);

        EditorGUILayout.Space();

        if (GUILayout.Button("Read Splines"))
        {
            foreach (TextAsset xml in xmlsToRead)
            {
                if (xml == null) continue;
                ReadSplines(xml);
                TranslateSplines(xml);
            }
        }

        if (GUILayout.Button("Translate Splines"))
        {
            foreach (TextAsset xml in xmlsToRead)
            {
                if (xml == null) continue;
                TranslateSplines(xml);
            }
        }

        so.ApplyModifiedProperties();
    }

    void ReadSplines(TextAsset xmlToRead)
    {
        XmlDocument xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(xmlToRead.text);

        foreach (XmlNode node0 in xmlDocument.ChildNodes)
        {
            switch (node0.Name)
            {
                case "SonicPath":

                    foreach (XmlNode a in node0.ChildNodes)
                    {
                        switch (a.Name)
                        {
                            case "library":
                                foreach (XmlNode b in a.ChildNodes)
                                {
                                    switch (b.Name)
                                    {
                                        case "geometry":
                                            GameObject gas = new GameObject(b.Attributes[0].Value.Replace("-geometry", string.Empty));

                                            foreach (XmlNode c in b.ChildNodes)
                                            {
                                                switch (c.Name)
                                                {
                                                    case "spline":
                                                        foreach (XmlNode d in c.ChildNodes)
                                                        {

                                                            switch (d.Name)
                                                            {
                                                                case "spline3d":
                                                                    GameObject go = new GameObject(d.Name);
                                                                    go.transform.parent = gas.transform;
                                                                    BezierSpline bezierSpline = go.AddComponent<BezierSpline>();

                                                                    bezierSpline.bezierControlPoints.Clear();



                                                                    foreach (XmlNode e in d.ChildNodes)
                                                                    {
                                                                        BezierControlPoint controlPoint = new BezierControlPoint();

                                                                        switch (e.Attributes[0].Value)
                                                                        {
                                                                            case "auto":
                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }
                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }
                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case "bezier":

                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }
                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }
                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;

                                                                            case "corner":
                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }
                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }
                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;

                                                                            case "bezier_corner":
                                                                                foreach (XmlNode f in e.ChildNodes)
                                                                                {
                                                                                    if (f.Name == "invec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.invec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "outvec")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.outvec = ParseVector3FromArray(sts);
                                                                                    }

                                                                                    if (f.Name == "point")
                                                                                    {
                                                                                        string[] sts = f.InnerText.Split(' ');
                                                                                        controlPoint.point = ParseVector3FromArray(sts);
                                                                                    }
                                                                                }
                                                                                break;
                                                                        }
                                                                        bezierSpline.bezierControlPoints.Add(controlPoint);
                                                                    }
                                                                    Vector3 direction = (gas.transform.position - bezierSpline.GetPoint(0)).normalized;

                                                                    if (gas.transform.childCount < 2)
                                                                    {
                                                                        go.name = "right";
                                                                    }
                                                                    else
                                                                    {
                                                                        go.name = "left";
                                                                    }
                                                                    break;


                                                            }
                                                        }


                                                        break;
                                                }
                                            }



                                            try
                                            {
                                                DualBezierSpline dualBezierSpline = gas.AddComponent<DualBezierSpline>();

                                                gas.AddComponent<BezierPath>();

                                                DualBezierSplineCollider dualBezierSplineCollider = gas.AddComponent<DualBezierSplineCollider>();

                                                dualBezierSplineCollider.iterations = 300;

                                                if (gas.transform.Find("right") && gas.transform.Find("left"))
                                                {
                                                    dualBezierSplineCollider.CreateMesh();
                                                }

                                                gas.layer = LayerMask.NameToLayer("Spline Collision");
                                            }
                                            catch
                                            {

                                            }

                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                    }
                    break;
            }
        }
    }

    void TranslateSplines(TextAsset xmlToRead)
    {
        XmlDocument xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(xmlToRead.text);

        foreach (XmlNode node0 in xmlDocument.ChildNodes)
        {
            switch (node0.Name)
            {
                case "SonicPath":
                    foreach (XmlNode a in node0.ChildNodes)
                    {
                        switch (a.Name)
                        {
                            case "scene":
                                foreach (XmlNode node in xmlDocument.SelectNodes("//node"))
                                {
                                    string id = node.Attributes["id"]?.Value;

                                    if (string.IsNullOrEmpty(id))
                                        continue;

                                    GameObject go = GameObject.Find(id);

                                    if (go == null)
                                    {
                                        Debug.LogWarning($"GameObject {id} não encontrado.");
                                        continue;
                                    }

                                    foreach (XmlNode child in node.ChildNodes)
                                    {
                                        switch (child.Name)
                                        {
                                            case "translate":
                                                string[] pos = child.InnerText.Split(' ');
                                                go.transform.position = new Vector3(
                                                    -float.Parse(pos[0], CultureInfo.InvariantCulture),
                                                     float.Parse(pos[1], CultureInfo.InvariantCulture),
                                                     float.Parse(pos[2], CultureInfo.InvariantCulture));
                                                break;

                                            case "scale":
                                                string[] scale = child.InnerText.Split(' ');
                                                go.transform.localScale = new Vector3(
                                                    -float.Parse(scale[0], CultureInfo.InvariantCulture),
                                                     float.Parse(scale[1], CultureInfo.InvariantCulture),
                                                     float.Parse(scale[2], CultureInfo.InvariantCulture));
                                                break;

                                            case "rotate":
                                                string[] rot = child.InnerText.Split(' ');

                                                Quaternion rotation = new Quaternion(
                                                    float.Parse(rot[0], CultureInfo.InvariantCulture),
                                                    float.Parse(rot[1], CultureInfo.InvariantCulture),
                                                    float.Parse(rot[2], CultureInfo.InvariantCulture),
                                                    float.Parse(rot[3], CultureInfo.InvariantCulture));

                                                go.transform.rotation = ConvertToEuler(rotation);
                                                break;
                                        }
                                    }
                                }

                                break;
                        }
                    }
                    break;
            }
        }
    }

    private Quaternion ConvertToEuler(Quaternion currentRotation)
    {
        currentRotation.Normalize();
        var euler = currentRotation.eulerAngles;
        return Quaternion.Euler(euler.x, -euler.y, -euler.z);
    }

    private Vector3 ParseVector3FromArray(string[] floats)
    {
        return new Vector3(float.Parse(floats[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[2], CultureInfo.InvariantCulture.NumberFormat));
    }

    private Vector3 ParseQuaternionFromArray(string[] floats)
    {
        return new Vector3(float.Parse(floats[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(floats[2], CultureInfo.InvariantCulture.NumberFormat));
    }
}