using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Counter : EditorWindow
{

    string tag = "Untagged";

    bool setSiblingIndex;

    new string name;

    GameObject detailA;

    GameObject node;

    GameObject lookObject;

    GameObject siblingParent;

    string siblingName;


    [MenuItem("Ring Engine/Counter")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Counter), false, "Counter");
    }

    public List<Vector3> right = new List<Vector3>();
    public List<Vector3> left = new List<Vector3>();


    int siblingIndex;


    void OnSelectionChange()
    {
        if (setSiblingIndex)
        {
            Selection.transforms[0].SetSiblingIndex(siblingIndex);
            Selection.transforms[0].parent = siblingParent.transform;
            Selection.transforms[0].name = siblingName + " " + siblingIndex.ToString();
            siblingIndex++;
        }

    }
    void OnGUI()
    {

        Handles.DrawPolyLine(right.ToArray());

        node = EditorGUILayout.ObjectField(node, typeof(GameObject), true) as GameObject;

        lookObject = EditorGUILayout.ObjectField(lookObject, typeof(GameObject), true) as GameObject;

        detailA = EditorGUILayout.ObjectField(detailA, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Create Details"))
        {
            for (int j = 0; j < Selection.gameObjects.Length; j++)
            {
                Mesh mesh = Selection.gameObjects[j].GetComponent<MeshFilter>().sharedMesh;

                for (int i = 0; i < mesh.vertexCount; i++)
                {
                    Instantiate(detailA, mesh.vertices[i], Quaternion.identity);
                }

                foreach (Vector3 vertex in mesh.vertices)
                {
                    Instantiate(detailA, vertex, Quaternion.identity);
                }
            }
        }



        EditorGUILayout.Separator();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Count with the tag");
        EditorGUILayout.EndVertical();

        tag = EditorGUILayout.TagField(tag);

        if (tag != "Untagged")
        {
            int amount = GameObject.FindGameObjectsWithTag(tag).Length;
            string text = (amount > 1) ? " GameObjects with the tag " : " GameObject with the tag ";
            EditorGUILayout.HelpBox(amount + text + tag, MessageType.Info);
        }

        EditorGUI.BeginChangeCheck();
        if (Selection.gameObjects.Length > 0)
        {
            int amount = Selection.gameObjects.Length;
            string text = (amount > 1) ? " GameObjects selected " : " GameObject selected ";
            EditorGUILayout.HelpBox(amount + text, MessageType.Info);
        }

        if (GUILayout.Button("Align to ground normal"))
        {
            for (int j = 0; j < Selection.gameObjects.Length; j++)
            {
                var hit = new RaycastHit();

                Physics.Raycast(Selection.gameObjects[j].transform.position, -Selection.gameObjects[j].transform.up, out hit);

                Selection.gameObjects[j].transform.rotation = Quaternion.LookRotation(Selection.gameObjects[j].transform.forward, hit.normal);
            }
        }

        if (GUILayout.Button("Align to ground normal"))
        {
            for (int j = 0; j < Selection.gameObjects.Length; j++)
            {
                var hit = new RaycastHit();

                Physics.Raycast(Selection.gameObjects[j].transform.position, -Selection.gameObjects[j].transform.up, out hit);

                Selection.gameObjects[j].transform.rotation = Quaternion.LookRotation(Selection.gameObjects[j].transform.forward, hit.normal);
            }
        }

        if (GUILayout.Button("Look To Object"))
        {
            for (int j = 0; j < Selection.gameObjects.Length; j++)
            {
                Selection.gameObjects[j].transform.LookAt(lookObject.transform);
            }
        }

        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            int amount = Selection.gameObjects[i].transform.childCount;
            string text = (amount > 1) ? " childs " : " child ";
            if (amount > 0)
            {
                EditorGUILayout.HelpBox(Selection.gameObjects[i].name + " - " + amount + text, MessageType.Info);
                EditorGUILayout.LabelField("Rename");
                name = EditorGUILayout.TextField(name);
                if (GUILayout.Button("Rename"))
                {
                    for (int j = 0; j < Selection.gameObjects[i].transform.childCount; j++)
                    {
                        Selection.gameObjects[i].transform.GetChild(j).name = name + " " + (j + 1);
                    }
                }


            }
        }

        if (GUILayout.Button("Create Vertex Objects"))
        {
            foreach (Vector3 vertice in Selection.gameObjects[0].GetComponent<MeshFilter>().sharedMesh.vertices)
            {
                Instantiate(node, vertice, Quaternion.identity);
            }
        }


        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("Sibling Organization");

        siblingName = EditorGUILayout.TextField("Sibling Name", siblingName);

        if (GUILayout.Button("Create Sibling Parent"))
        {
            if (siblingName != string.Empty)
            {
                siblingParent = new GameObject(siblingName);
            }
        }

        setSiblingIndex = EditorGUILayout.Toggle("Set Sibling Index", setSiblingIndex);

        if (setSiblingIndex)
        {
            EditorGUILayout.HelpBox("Click one object per time then it will be seted by the order you are clicking", MessageType.Info);

            if (GUILayout.Button("Clear Index"))
            {
                siblingIndex = 0;
            }
        }







        EditorGUI.EndChangeCheck();
    }

    public void OnInspectorUpdate()
    {
        Repaint();
    }
}