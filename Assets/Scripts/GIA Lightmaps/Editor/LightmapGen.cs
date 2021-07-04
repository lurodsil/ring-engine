using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LightmapGen : EditorWindow
{
    [MenuItem("Ring Engine/Juliana")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LightmapGen), false, "Lightmap Gen");
    }

    GiaReader giaReader = new GiaReader();

    string giaFormat = "*.dds";
    string giaFolder = "Assets/Gia/";
    string atlasInfoFolder = "Assets/Gia/Atlas Info/";

    string materialsFolder = "Assets/Stages/Dragon Road/Materials/";
    string texturesFolder = "Assets/Stages/Dragon Road/Textures/";

    string[] targetMaterials;
    string[] materialsNames;
    string[] textures;
    string[] textureNames;

    bool readAlbedo;
    bool readGloss;
    bool readNormal;
    bool readEmission;

    string textureFormat = ".psd";

    void OnGUI()
    {
        atlasInfoFolder = EditorGUILayout.TextField("Atlas Info Folder", atlasInfoFolder);
        giaFolder = EditorGUILayout.TextField("Gia Folder", giaFolder);
        giaFormat = EditorGUILayout.TextField("Gia Format", giaFormat);

        if (GUILayout.Button("Lightmap Setup"))
        {
            giaReader.SetupLightmaps(giaFolder, giaFormat);
        }
        if (GUILayout.Button("Read Atlas Info"))
        {
            giaReader.ReadAtlas(atlasInfoFolder);
        }
        if (GUILayout.Button("Read Extra Textures"))
        {
            giaReader.ReadLightmapExtra(giaFolder, giaFormat, "");
        }

        EditorGUILayout.BeginHorizontal();
        materialsFolder = EditorGUILayout.TextField("Materials Folder", materialsFolder);
        if (GUILayout.Button("Search"))
        {
            materialsFolder = "Assets" + EditorUtility.OpenFolderPanel("Materials Folder", materialsFolder, "").Replace(Application.dataPath, "");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        texturesFolder = EditorGUILayout.TextField("Textures Folder", texturesFolder);
        if (GUILayout.Button("Search"))
        {
            texturesFolder = "Assets" + EditorUtility.OpenFolderPanel("Textures Folder", texturesFolder, "").Replace(Application.dataPath, "");
        }
        EditorGUILayout.EndHorizontal();

        textureFormat = EditorGUILayout.TextField("Textures Format", textureFormat);


        readAlbedo = EditorGUILayout.Toggle("Albedo", readAlbedo);
        readGloss = EditorGUILayout.Toggle("Gloss", readGloss);
        readNormal = EditorGUILayout.Toggle("Normal", readNormal);
        readEmission = EditorGUILayout.Toggle("Emission", readEmission);




        if (GUILayout.Button("Setup Materials"))
        {
            targetMaterials = Directory.GetFiles(materialsFolder, "*.mat");
            materialsNames = GetFileNamesWithoutExtension(targetMaterials);
            textures = Directory.GetFiles(texturesFolder, "*" + textureFormat);
            textureNames = GetFileNamesWithoutExtension(textures);

            for (int i = 0; i < materialsNames.Length; i++)
            {
                Material mat = AssetDatabase.LoadAssetAtPath(targetMaterials[i], typeof(Material)) as Material;

                if (readAlbedo)
                {
                    try
                    {
                        Texture diffuse = AssetDatabase.LoadAssetAtPath(textures[GetArrayIndex(textureNames, materialsNames[i])], typeof(Texture)) as Texture;
                        mat.SetTexture("_MainTex", diffuse);
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e);
                    }
                }

                if (readGloss)
                {
                    try
                    {
                        Texture gloss = AssetDatabase.LoadAssetAtPath(textures[GetArrayIndex(textureNames, materialsNames[i].Replace("_dif", "_pow"))], typeof(Texture)) as Texture;
                        mat.SetTexture("_GlossMap", gloss);
                    }
                    catch
                    {

                    }
                }

                if (readNormal)
                {
                    try
                    {
                        Texture normal = AssetDatabase.LoadAssetAtPath(textures[GetArrayIndex(textureNames, materialsNames[i].Replace("_dif", "_nrm"))], typeof(Texture)) as Texture;
                        mat.SetTexture("_BumpMap", normal);
                    }
                    catch
                    {

                    }
                }

                if (readEmission)
                {
                    try
                    {
                        Texture emission = AssetDatabase.LoadAssetAtPath(textures[GetArrayIndex(textureNames, materialsNames[i].Replace("_dif", "_ems"))], typeof(Texture)) as Texture;
                        mat.SetColor("_EmissionColor", Color.white);
                        mat.SetTexture("_EmissionMap", emission);
                    }
                    catch
                    {
                        try
                        {
                            Texture emission = AssetDatabase.LoadAssetAtPath(textures[GetArrayIndex(textureNames, materialsNames[i].Replace("_dif", "_lim"))], typeof(Texture)) as Texture;
                            mat.SetColor("_EmissionColor", Color.white);
                            mat.SetTexture("_EmissionMap", emission);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }

    int GetArrayIndex(string[] array, string contains)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Contains(contains))
            {
                return i;
            }
        }
        return -1;
    }

    string[] GetFileNamesWithoutExtension(string[] filePathes)
    {
        string[] fileNames = new string[filePathes.Length];

        for (int i = 0; i < fileNames.Length; i++)
        {
            fileNames[i] = Path.GetFileNameWithoutExtension(filePathes[i]);
        }

        return fileNames;
    }
}
