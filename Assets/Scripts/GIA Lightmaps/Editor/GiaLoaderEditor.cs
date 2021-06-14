using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GiaLoader))]
public class GiaLoaderEditor : Editor
{
    GiaReader giaReader = new GiaReader();

    public override void OnInspectorGUI()
    {
        GiaLoader giaLoader = (GiaLoader)target;

        if (GUILayout.Button("Get Lightmaps From Folder"))
        {
            giaLoader.lightmapsTextures = giaReader.GetLightmapsFromFolder(giaLoader.giaFolder, giaLoader.giaFormat);
        }

        if (GUILayout.Button("Setup Lightmaps"))
        {
            giaLoader.SetupLightmaps();
        }

        DrawDefaultInspector();
    }
}
