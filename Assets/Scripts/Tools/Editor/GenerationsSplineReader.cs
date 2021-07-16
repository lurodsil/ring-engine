using System.Globalization;
using System.Xml;
using UnityEditor;
using UnityEngine;


public class GenerationsSplineReader : EditorWindow
{
    TextAsset xmlToRead;
    [MenuItem("Window/Ring Engine Tools/Generations Spline Reader")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GenerationsSplineReader), false, "XML Reader");
    }

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        xmlToRead = EditorGUILayout.ObjectField("XML File", xmlToRead, typeof(TextAsset), false) as TextAsset;

        if (GUILayout.Button("Read Splines"))
        {
            ReadSplines();

            TranslateSplines();
        }
    }

    void ReadSplines()
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
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                }
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

    void TranslateSplines()
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
                                foreach (XmlNode b in a.ChildNodes)
                                {
                                    switch (b.Name)
                                    {
                                        case "node":

                                            //GameObject gas = GameObject.Find(b.Attributes[0].Value);
                                            //Dragon Road Spline
                                            GameObject gas = GameObject.Find(b.Attributes[0].Value + "-spline");


                                            foreach (XmlNode c in b.ChildNodes)
                                            {
                                                switch (c.Name)
                                                {
                                                    case "translate":
                                                        string[] pos = c.InnerText.Split(' ');
                                                        gas.transform.position = new Vector3(-float.Parse(pos[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(pos[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(pos[2], CultureInfo.InvariantCulture.NumberFormat));
                                                        break;
                                                    case "scale":
                                                        string[] size = c.InnerText.Split(' ');
                                                        gas.transform.localScale = new Vector3(-float.Parse(size[0], CultureInfo.InvariantCulture.NumberFormat), float.Parse(size[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(size[2], CultureInfo.InvariantCulture.NumberFormat));
                                                        break;
                                                    case "rotate":
                                                        string[] rot = c.InnerText.Split(' ');
                                                        gas.transform.rotation = new Quaternion(float.Parse(rot[0], CultureInfo.InvariantCulture.NumberFormat), -float.Parse(rot[1], CultureInfo.InvariantCulture.NumberFormat), float.Parse(rot[2], CultureInfo.InvariantCulture.NumberFormat), float.Parse(rot[3], CultureInfo.InvariantCulture.NumberFormat));
                                                        break;
                                                }
                                            }
                                            break;
                                    }
                                }

                                break;
                        }
                    }
                    break;
            }
        }
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