using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class HE1MaterialAutoSetup : EditorWindow
{
    private const int BASE_OFFSET = 0x18;

    string texturesFolder = "Assets/";
    string textureExtension = ".tga";

    [MenuItem("Tools/Hedgehog Engine 1/Auto Apply Materials")]
    public static void ShowWindow()
    {
        GetWindow<HE1MaterialAutoSetup>("HE1 Auto Material");
    }

    void OnGUI()
    {
        GUILayout.Space(10);

        EditorGUILayout.LabelField("Textures Folder (Unity)", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        texturesFolder = EditorGUILayout.TextField(texturesFolder);

        if (GUILayout.Button("Select", GUILayout.Width(80)))
        {
            string path = EditorUtility.OpenFolderPanel("Select Textures Folder", texturesFolder, "");

            if (!string.IsNullOrEmpty(path))
                texturesFolder = "Assets" + path.Replace(Application.dataPath, "");
        }
        EditorGUILayout.EndHorizontal();

        textureExtension = EditorGUILayout.TextField("Texture Extension", textureExtension);

        GUILayout.Space(20);

        if (GUILayout.Button("SELECT .material FOLDER AND APPLY", GUILayout.Height(40)))
        {
            ApplyMaterials();
        }
    }

    void ApplyMaterials()
    {
        string folder = EditorUtility.OpenFolderPanel("Select .material Folder", "", "");

        if (string.IsNullOrEmpty(folder))
            return;

        string[] materialFiles = Directory.GetFiles(folder, "*.material", SearchOption.AllDirectories);

        if (materialFiles.Length == 0)
        {
            Debug.LogWarning("Nenhum .material encontrado.");
            return;
        }

        // 🔹 Cache de texturas
        string[] texturePaths = Directory.GetFiles(texturesFolder, "*" + textureExtension, SearchOption.AllDirectories);
        Dictionary<string, string> textureMap = new();

        foreach (var texPath in texturePaths)
        {
            string name = Path.GetFileNameWithoutExtension(texPath);
            if (!textureMap.ContainsKey(name))
                textureMap.Add(name, texPath);
        }

        // 🔹 Cache de materiais Unity (evita FindAssets toda hora)
        string[] allMaterialGuids = AssetDatabase.FindAssets("t:Material");
        Dictionary<string, Material> unityMaterialMap = new();

        foreach (var guid in allMaterialGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && !unityMaterialMap.ContainsKey(mat.name))
                unityMaterialMap.Add(mat.name, mat);
        }

        int appliedCount = 0;

        foreach (var matFile in materialFiles)
        {
            string unityMaterialName = Path.GetFileNameWithoutExtension(matFile);

            if (!unityMaterialMap.TryGetValue(unityMaterialName, out Material unityMat))
                continue;

            // 🔹 Primeiro tenta pegar do .material
            string difName = ReadDifTextureName(matFile);

            string baseName;

            if (!string.IsNullOrEmpty(difName))
            {
                baseName = NormalizeBaseName(difName);
            }
            else
            {
                baseName = NormalizeBaseName(unityMaterialName);
                Debug.Log($"Fallback ativado para: {unityMaterialName}");
            }

            ApplyTextureSmart(unityMat, baseName, textureMap);

            EditorUtility.SetDirty(unityMat);
            appliedCount++;
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"✅ Aplicado em {appliedCount} materiais.");
    }

    void ApplyTextureSmart(Material mat, string baseName, Dictionary<string, string> textureMap)
    {
        TryApply(mat, baseName + "_dif", "_BaseColorMap", textureMap);
        TryApply(mat, baseName + "_nrm", "_NormalMap", textureMap, true);
        TryApply(mat, baseName + "_pow", "_MaskMap", textureMap);
        TryApply(mat, baseName + "_dpn", "_EmissiveColorMap", textureMap);
        TryApply(mat, baseName + "_env", "_EmissiveColorMap", textureMap);
    }

    void TryApply(Material mat, string texName, string property, Dictionary<string, string> textureMap, bool isNormal = false)
    {
        if (!textureMap.TryGetValue(texName, out string path))
        {
            Debug.LogWarning($"Textura não encontrada: {texName}");
            return;
        }

        if (!mat.HasProperty(property))
        {
            Debug.LogWarning($"Material {mat.name} não tem propriedade {property}");
            return;
        }

        Texture tex = AssetDatabase.LoadAssetAtPath<Texture>(path);

        if (tex == null)
        {
            Debug.LogWarning($"Falha ao carregar textura: {path}");
            return;
        }

        mat.SetTexture(property, tex);

        if (isNormal)
            mat.EnableKeyword("_NORMALMAP");

        if (property == "_EmissiveColorMap")
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissiveColor", Color.white);
        }

        Debug.Log($"Aplicado {texName} em {mat.name}");
    }
    string NormalizeBaseName(string name)
    {
        string[] suffixes = { "_dif", "_nrm", "_pow", "_dpn", "_env" };

        foreach (var suffix in suffixes)
        {
            if (name.EndsWith(suffix))
                return name.Substring(0, name.Length - suffix.Length);
        }

        return name;
    }

    // =================================
    // LÊ SOMENTE O _dif DO .material
    // =================================

    string ReadDifTextureName(string path)
    {
        using var fs = File.OpenRead(path);
        using var reader = new BinaryReader(fs);

        long fileLength = reader.BaseStream.Length;

        uint ReadUInt32BE()
        {
            var b = reader.ReadBytes(4);
            Array.Reverse(b);
            return BitConverter.ToUInt32(b, 0);
        }

        string ReadStringAt(uint offset)
        {
            long pos = offset + BASE_OFFSET;

            if (pos <= 0 || pos >= fileLength)
                return null;

            long original = reader.BaseStream.Position;
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);

            List<byte> bytes = new();
            byte c;

            while (reader.BaseStream.Position < fileLength &&
                   (c = reader.ReadByte()) != 0)
            {
                bytes.Add(c);
            }

            reader.BaseStream.Seek(original, SeekOrigin.Begin);

            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        reader.BaseStream.Seek(0x18, SeekOrigin.Begin);

        reader.ReadUInt32();
        reader.ReadUInt32();

        ReadUInt32BE();
        uint textureOffset = ReadUInt32BE();

        reader.ReadUInt32();

        reader.ReadByte();
        reader.ReadBytes(2);
        byte totalTextures = reader.ReadByte();

        reader.ReadUInt32();
        reader.ReadUInt32();
        reader.ReadUInt32();

        if (totalTextures == 0)
            return null;

        reader.BaseStream.Seek(textureOffset + BASE_OFFSET, SeekOrigin.Begin);

        uint texOffset = ReadUInt32BE();
        long texPos = texOffset + BASE_OFFSET;

        reader.BaseStream.Seek(texPos, SeekOrigin.Begin);

        uint nameOffset = ReadUInt32BE();

        string name = ReadStringAt(nameOffset);

        if (name != null && name.EndsWith("_dif"))
            return name;

        return null;
    }
}
