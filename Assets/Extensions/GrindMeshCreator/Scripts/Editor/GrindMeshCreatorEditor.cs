using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GrindMeshCreator))]
public class GrindMeshCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GrindMeshCreator grindMeshCreator = (GrindMeshCreator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create Mesh"))
        {
            grindMeshCreator.CreateMesh();
        }

        if (GUILayout.Button("Erase Mesh"))
        {
            grindMeshCreator.EraseMesh();
        }
    }
}