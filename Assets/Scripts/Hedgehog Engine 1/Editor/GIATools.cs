using System.IO;
using UnityEditor;
using UnityEngine;

public class GIATools: EditorWindow
{
    [MenuItem("Tools/Hedgehog Engine 1/GIA Tools")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GIATools), false, "GIA Tools");
    }

    GiaReader giaReader = new GiaReader();

    string giaFormat = "*.dds";
    string giaFolder = "Assets/Gia/";

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

    string textureFormat = ".tga";

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        giaFolder = EditorGUILayout.TextField("Gia Folder", giaFolder);

        if (GUILayout.Button("Search"))
        {
            giaFolder = "Assets" + EditorUtility.OpenFolderPanel("Gia Folder", giaFolder, "").Replace(Application.dataPath, "");
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Read Atlas Info"))
        {
            giaReader.ReadAtlas(giaFolder);
        }

        EditorGUILayout.Space(20);

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
            targetMaterials = Directory.GetFiles(materialsFolder, "*.mat", SearchOption.AllDirectories);
            materialsNames = GetFileNamesWithoutExtension(targetMaterials);

            textures = Directory.GetFiles(texturesFolder, "*" + textureFormat, SearchOption.AllDirectories);
            textureNames = GetFileNamesWithoutExtension(textures);

            for (int i = 0; i < materialsNames.Length; i++)
            {
                Material mat = AssetDatabase.LoadAssetAtPath<Material>(targetMaterials[i]);
                if (mat == null) continue;

                string baseName = RemoveLastSuffix(materialsNames[i]);

                // ===== ALBEDO =====
                if (readAlbedo)
                    SetTextureExact(mat, "_BaseColorMap", baseName + "_dif");

                // ===== NORMAL =====
                if (readNormal)
                {
                    if (SetTextureExact(mat, "_NormalMap", baseName + "_nrm"))
                        mat.EnableKeyword("_NORMALMAP");
                }

                // ===== POW (HDRP usa MaskMap, mas vamos usar direto por enquanto) =====
                if (readGloss)
                    SetTextureExact(mat, "_MaskMap", baseName + "_pow");

                // ===== EMISSION =====
                if (readEmission)
                {
                    if (SetTextureExact(mat, "_EmissiveColorMap", baseName + "_dpn"))
                    {
                        mat.SetColor("_EmissiveColor", Color.white);
                        mat.EnableKeyword("_EMISSION");
                    }
                }

                EditorUtility.SetDirty(mat);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("✅ Materiais configurados automaticamente.");
        }



        string RemoveLastSuffix(string name)
        {
            int lastUnderscore = name.LastIndexOf('_');

            if (lastUnderscore < 0)
                return name;

            return name.Substring(0, lastUnderscore);
        }

        bool SetTextureExact(Material mat, string property, string textureName)
        {
            for (int i = 0; i < textureNames.Length; i++)
            {
                if (textureNames[i] == textureName)
                {
                    Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(textures[i]);

                    if (tex != null && mat.HasProperty(property))
                    {
                        mat.SetTexture(property, tex);
                        return true;
                    }
                }
            }

            return false;
        }


        string GetBaseName(string fileName)
        {
            int lastUnderscore = fileName.LastIndexOf('_');

            if (lastUnderscore < 0)
                return fileName;

            return fileName.Substring(0, lastUnderscore);
        }




        bool SetTextureSafe(Material mat, string property, string textureName)
        {
            int index = GetArrayIndex(textureNames, textureName);

            if (index < 0)
                return false;

            Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(textures[index]);

            if (tex == null)
                return false;

            mat.SetTexture(property, tex);
            return true;
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
}
