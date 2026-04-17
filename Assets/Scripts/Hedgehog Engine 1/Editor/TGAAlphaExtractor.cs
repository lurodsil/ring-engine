using UnityEngine;
using UnityEditor;
using System.IO;

public class TGAAlphaExtractor
{
    [MenuItem("Tools/Extract Alpha To RGB (Choose Folders)")]
    static void ExtractAlphaFromFolder()
    {
        // Escolher pasta origem
        string sourceFolder = EditorUtility.OpenFolderPanel(
            "Select SOURCE Folder (TGA files)",
            Application.dataPath,
            ""
        );

        if (string.IsNullOrEmpty(sourceFolder))
            return;

        // Escolher pasta destino
        string targetFolder = EditorUtility.OpenFolderPanel(
            "Select TARGET Folder (Save TGAs)",
            Application.dataPath,
            ""
        );

        if (string.IsNullOrEmpty(targetFolder))
            return;

        string[] files = Directory.GetFiles(sourceFolder, "*.tga", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            string relativePath = "Assets" + file.Replace(Application.dataPath, "");
            TextureImporter importer = AssetImporter.GetAtPath(relativePath) as TextureImporter;

            if (importer == null)
                continue;

            importer.isReadable = true;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
            importer.SaveAndReimport();

            Texture2D source = AssetDatabase.LoadAssetAtPath<Texture2D>(relativePath);
            if (source == null)
                continue;

            Texture2D newTex = new Texture2D(source.width, source.height, TextureFormat.RGB24, false);

            Color[] pixels = source.GetPixels();
            Color[] newPixels = new Color[pixels.Length];

            for (int i = 0; i < pixels.Length; i++)
            {
                float a = pixels[i].a;
                newPixels[i] = new Color(a, a, a, 1f);
            }

            newTex.SetPixels(newPixels);
            newTex.Apply();

            string fileName = Path.GetFileNameWithoutExtension(file);
            string newPath = Path.Combine(targetFolder, fileName + "_alpha.tga");

            SaveAsTGA(newTex, newPath);
        }

        AssetDatabase.Refresh();
        Debug.Log("Finished extracting alpha to TGA.");
    }

    static void SaveAsTGA(Texture2D tex, string path)
    {
        int width = tex.width;
        int height = tex.height;

        Color32[] pixels = tex.GetPixels32();

        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            // Header TGA
            bw.Write((byte)0);
            bw.Write((byte)0);
            bw.Write((byte)2);

            bw.Write((short)0);
            bw.Write((short)0);
            bw.Write((byte)0);

            bw.Write((short)0);
            bw.Write((short)0);
            bw.Write((short)width);
            bw.Write((short)height);
            bw.Write((byte)24);
            bw.Write((byte)0);

            // Pixel data (BGR)
            for (int i = 0; i < pixels.Length; i++)
            {
                bw.Write(pixels[i].b);
                bw.Write(pixels[i].g);
                bw.Write(pixels[i].r);
            }
        }
    }
}