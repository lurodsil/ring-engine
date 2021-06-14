using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GiaReader
{
    string[] GetFileNamesWithoutExtension(string[] filePathes)
    {
        string[] fileNames = new string[filePathes.Length];

        for (int i = 0; i < fileNames.Length; i++)
        {
            fileNames[i] = Path.GetFileNameWithoutExtension(filePathes[i]);
        }

        return fileNames;
    }

    public Texture2D[] GetLightmapsFromFolder(string giaFolder, string giaExtension)
    {
        string[] giaPaths = Directory.GetFiles(giaFolder, giaExtension);

        Texture2D[] lightmaps = new Texture2D[giaPaths.Length];

        for (int i = 0; i < lightmaps.Length; i++)
        {
            lightmaps[i] = AssetDatabase.LoadAssetAtPath(giaPaths[i], typeof(Texture2D)) as Texture2D;
        }

        return lightmaps;
    }

    public void SetupLightmaps(string giaFolder, string giaExtension)
    {
        string[] giaPath = Directory.GetFiles(giaFolder, giaExtension);

        LightmapData[] lightmaps = new LightmapData[giaPath.Length];

        for (int i = 0; i < lightmaps.Length; i++)
        {
            lightmaps[i] = new LightmapData();
            lightmaps[i].lightmapColor = AssetDatabase.LoadAssetAtPath(giaPath[i], typeof(Texture2D)) as Texture2D;
        }

        LightmapSettings.lightmaps = lightmaps;
    }

    public int ReadLightmapExtra(string giaFolder, string giaExtension, string ss)
    {
        int index = -1;

        string[] giaNames = GetFileNamesWithoutExtension(Directory.GetFiles(giaFolder, giaExtension));

        List<string> giaExtra = new List<string>();

        foreach (string s in giaNames)
        {
            if (s.Contains("level0"))
            {
                giaExtra.Add(s);
            }
        }

        for (int i = 0; i < giaExtra.Count; i++)
        {
            for (int j = 0; j < giaExtra[i].Length; j++)
            {
                if (giaExtra[i][0] != '.')
                {
                    giaExtra[i] = giaExtra[i].Remove(0, 1);
                }
                else
                {
                    giaExtra[i] = giaExtra[i].Remove(0, 4);
                    giaExtra[i] = giaExtra[i].Replace("-level0", string.Empty);
                    j = giaExtra[i].Length;
                }
            }

            GameObject go = GameObject.Find(giaExtra[i]);

            if (!go.GetComponent<LightmapInfo>())
            {
                go.AddComponent<LightmapInfo>();
            }


            go.GetComponent<LightmapInfo>().lightmapIndex = FindLightmapIndex(giaExtra[i]);
        }
        return index;
    }

    int FindLightmapIndex(string name)
    {
        for (int i = 0; i < LightmapSettings.lightmaps.Length; i++)
        {
            if (LightmapSettings.lightmaps[i].lightmapColor.name.Contains(name))
            {
                return i;
            }
        }
        return -1;
    }

    int FindArrayIndex(string[] array, string name)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Contains(name))
            {
                return i;
            }
        }
        return -1;
    }

    int FindArrayIndex(string[] array, string name, string filter)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Contains(name) && array[i].Contains(filter))
            {
                return i;
            }
        }
        return -1;
    }

    int FindLightmapIndex(string name, string filter)
    {
        for (int i = 0; i < LightmapSettings.lightmaps.Length; i++)
        {
            if (LightmapSettings.lightmaps[i].lightmapColor.name.Contains(name) && LightmapSettings.lightmaps[i].lightmapColor.name.Contains(filter))
            {
                return i;
            }
        }
        return -1;
    }

    public void ReadAtlas(string atlasFolder)
    {
        string[] atlasInfoPathes = Directory.GetFiles(atlasFolder, "*.ar-atlasinfo");

        string[] atlasInfoNames = GetFileNamesWithoutExtension(atlasInfoPathes);

        string[] giaFiles = GetFileNamesWithoutExtension(Directory.GetFiles(atlasFolder, "*.dds"));

        for (int i = 0; i < atlasInfoPathes.Length; i++)
        {
            FileStream fileStream = new FileStream(atlasInfoPathes[i], FileMode.Open);

            BinaryReader binaryReader = new BinaryReader(fileStream);

            AtlasInfo.AtlasInfoHeader atlasInfoHeader = new AtlasInfo.AtlasInfoHeader();
            AtlasInfo.TextureHeader textureHeader = new AtlasInfo.TextureHeader();
            AtlasInfo.SubTextureInfo subTextureInfo = new AtlasInfo.SubTextureInfo();

            atlasInfoHeader.padding = binaryReader.ReadChar();
            atlasInfoHeader.texturesAmount = binaryReader.ReadByte();
            atlasInfoHeader.addPadding = binaryReader.ReadChar();

            for (int j = 0; j < atlasInfoHeader.texturesAmount; j++)
            {
                textureHeader.textureNameSize = binaryReader.ReadByte();
                textureHeader.textureName = binaryReader.ReadChars(textureHeader.textureNameSize);
                textureHeader.subTextureSize = binaryReader.ReadByte();
                textureHeader.padding = binaryReader.ReadChar();

                int lightmapIndex = FindArrayIndex(giaFiles, atlasInfoNames[i], new string(textureHeader.textureName));

                for (int k = 0; k < textureHeader.subTextureSize; k++)
                {
                    subTextureInfo.subtextureNameSize = binaryReader.ReadByte();
                    subTextureInfo.subtextureName = binaryReader.ReadChars(subTextureInfo.subtextureNameSize);
                    subTextureInfo.width = binaryReader.ReadByte();
                    subTextureInfo.height = binaryReader.ReadByte();
                    subTextureInfo.x = binaryReader.ReadByte();
                    subTextureInfo.y = binaryReader.ReadByte();

                    float x = (1 / Mathf.Pow(2, subTextureInfo.width - 1)) / 2;
                    float y = (1 / Mathf.Pow(2, subTextureInfo.height - 1)) / 2;
                    float z = RGB0255ToRGB01(subTextureInfo.x);
                    float w = 1 - (RGB0255ToRGB01(subTextureInfo.y) + y);

                    if (new string(subTextureInfo.subtextureName).Contains("level0"))
                    {
                        string subTextureNameCorrected = new string(subTextureInfo.subtextureName, 0, subTextureInfo.subtextureNameSize - 7);

                        if (GameObject.Find(subTextureNameCorrected))
                        {
                            GameObject go = GameObject.Find(subTextureNameCorrected);

                            if (!go.GetComponent<LightmapInfo>())
                            {
                                go.AddComponent<LightmapInfo>();
                            }

                            LightmapInfo lightmapInfo = go.GetComponent<LightmapInfo>();

                            lightmapInfo.lightmapIndex = lightmapIndex;

                            lightmapInfo.lightmapScaleOffset = new Vector4(x, y, z, w);
                        }
                    }
                }
            }

            binaryReader.Close();

            fileStream.Close();
        }
    }

    float RGB0255ToRGB01(int i)
    {
        return (i / 256.0f);
    }
}
