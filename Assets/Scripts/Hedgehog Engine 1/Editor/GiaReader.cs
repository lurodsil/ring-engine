using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GiaReader
{
    #region PUBLIC 
    public void ReadAtlas(string folder)
    {
        string[] atlasPaths = Directory.GetFiles(folder, "*.ar-atlasinfo");
        string[] ddsPaths = Directory.GetFiles(folder, "*.tga");

        string[] ddsNames = GetNames(ddsPaths);

        Dictionary<string, int> lightmapIndexMap = BuildLightmapIndexMap(ddsNames);

        GiaLightmapData asset = ScriptableObject.CreateInstance<GiaLightmapData>();
        asset.bindings = new List<GiaLightmapData.GameObjectBinding>();
        asset.directionalLightmaps = LoadTextures(folder+"/dir", "*.tga");
        asset.lightmaps = LoadTextures(folder, "*.tga");

        HashSet<string> alreadyBound = new HashSet<string>();

        ProcessAtlasInfos(atlasPaths, ddsNames, lightmapIndexMap, asset, alreadyBound);
        ProcessExtraLightmaps(ddsNames, lightmapIndexMap, asset, alreadyBound);

        SaveAsset(asset, folder);
    }

    #endregion

    #region CORE PROCESSING
    private void ProcessAtlasInfos(string[] atlasPaths, string[] ddsNames, Dictionary<string, int> indexMap, GiaLightmapData asset, HashSet<string> alreadyBound)
    {
        foreach (string atlasPath in atlasPaths)
        {
            string atlasName = Path.GetFileNameWithoutExtension(atlasPath);

            using FileStream fs = new FileStream(atlasPath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            br.ReadChar();
            byte textureCount = br.ReadByte();
            br.ReadChar();

            for (int t = 0; t < textureCount; t++)
            {
                byte nameSize = br.ReadByte();
                string textureName = new string(br.ReadChars(nameSize));
                byte subTexCount = br.ReadByte();
                br.ReadChar();

                int lightmapIndex = FindLightmapIndex(indexMap, atlasName, textureName);

                for (int s = 0; s < subTexCount; s++)
                {
                    string objectName = ReadSubTexture(br, out Vector4 scaleOffset);

                    if (!objectName.Contains("level0"))
                        continue;

                    objectName = CleanLevelName(objectName);

                    AddBinding(asset, alreadyBound, objectName, lightmapIndex, scaleOffset);
                }
            }
        }
    }

    private void ProcessExtraLightmaps(string[] ddsNames, Dictionary<string, int> indexMap, GiaLightmapData asset, HashSet<string> alreadyBound)
    {
        foreach (var name in ddsNames)
        {
            if (!name.Contains("level0"))
                continue;

            string cleanName = ExtractExtraName(name);

            if (alreadyBound.Contains(cleanName))
                continue;

            if (!indexMap.TryGetValue(name, out int index))
                continue;

            AddBinding(asset, alreadyBound, cleanName, index, new Vector4(1, 1, 0, 0));
        }
    }
    #endregion

    #region HELPERS
    private string[] GetNames(string[] paths)
    {
        string[] names = new string[paths.Length];
        for (int i = 0; i < paths.Length; i++)
            names[i] = Path.GetFileNameWithoutExtension(paths[i]);
        return names;
    }

    private Dictionary<string, int> BuildLightmapIndexMap(string[] names)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();

        for (int i = 0; i < names.Length; i++)
            map[names[i]] = i;

        return map;
    }

    private Texture2D[] LoadTextures(string folder, string extension)
    {
        string[] paths = Directory.GetFiles(folder, extension);
        Texture2D[] textures = new Texture2D[paths.Length];

        for (int i = 0; i < paths.Length; i++)
            textures[i] = AssetDatabase.LoadAssetAtPath<Texture2D>(paths[i]);

        return textures;
    }

    private string ReadSubTexture(BinaryReader br, out Vector4 scaleOffset)
    {
        byte nameSize = br.ReadByte();
        string name = new string(br.ReadChars(nameSize));

        byte width = br.ReadByte();
        byte height = br.ReadByte();
        byte x = br.ReadByte();
        byte y = br.ReadByte();

        float scaleX = 1f / Mathf.Pow(2, width);
        float scaleY = 1f / Mathf.Pow(2, height);
        float offsetX = x / 256f;
        float offsetY = 1f - (y / 256f + scaleY);

        scaleOffset = new Vector4(scaleX, scaleY, offsetX, offsetY);

        return name;
    }

    private void AddBinding(GiaLightmapData asset, HashSet<string> alreadyBound, string name, int index, Vector4 scaleOffset)
    {
        if (index < 0)
            return;

        asset.bindings.Add(new GiaLightmapData.GameObjectBinding
        {
            gameObjectName = name,
            lightmapIndex = index,
            scaleOffset = scaleOffset
        });

        alreadyBound.Add(name);
    }

    private int FindLightmapIndex(Dictionary<string, int> indexMap, string atlasName, string filter)
    {
        foreach (var pair in indexMap)
        {
            if (pair.Key.Contains(atlasName) && pair.Key.Contains(filter))
                return pair.Value;
        }

        return -1;
    }

    private string CleanLevelName(string name)
    {
        return name.Replace("-level0", "");
    }

    private string ExtractExtraName(string name)
    {
        int split = name.IndexOf(".ar-");
        if (split >= 0)
            name = name.Substring(split + 4);

        return CleanLevelName(name);
    }

    private void SaveAsset(GiaLightmapData asset, string folder)
    {
        // pega pasta superior
        string parentFolder = Directory.GetParent(folder).FullName;

        // Unity precisa de caminho relativo a Assets
        parentFolder = parentFolder.Replace("\\", "/");

        if (parentFolder.Contains(Application.dataPath))
            parentFolder = "Assets" + parentFolder.Replace(Application.dataPath, "");

        string path = parentFolder + "/GiaLightmapData.asset";

        AssetDatabase.DeleteAsset(path);
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();

        Debug.Log("GiaLightmapData created in: " + path);
    }
    #endregion
}
