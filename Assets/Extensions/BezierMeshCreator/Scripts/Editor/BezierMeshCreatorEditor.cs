using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierMeshCreator))]
public class BezierMeshCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BezierMeshCreator meshCreator = (BezierMeshCreator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create and bake mesh"))
        {
            meshCreator.CreatAllMeshes();
        }

        if (GUILayout.Button("Erase mesh"))
        {
            foreach (BezierMeshStructure meshStructure in meshCreator.structures)
            {
                meshCreator.EraseMesh(meshStructure.name);
            }
        }

        if (GUILayout.Button("Create Decorations"))
        {
            meshCreator.CreateDecorations();
        }

        if (GUILayout.Button("Erase decorations"))
        {

            meshCreator.EraseMesh("Decorations");

        }
    }
}