using UnityEngine;
using UnityEditor;
using System.IO;

public class SeparateAlpha
{
    [MenuItem("Tools/Separate Alpha To New TGA")]
    static void Convert()
    {
        Texture2D source = Selection.activeObject as Texture2D;

        if (source == null)
        {
            Debug.LogError("Selecione uma textura TGA no Project.");
            return;
        }

        string path = AssetDatabase.GetAssetPath(source);
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

        // Garantir leitura
        importer.isReadable = true;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.alphaSource = TextureImporterAlphaSource.FromInput;
        importer.SaveAndReimport();

        source = AssetDatabase.LoadAssetAtPath<Texture2D>(path);

        int width = source.width;
        int height = source.height;

        Color32[] pixels = source.GetPixels32();

        Texture2D alphaTex = new Texture2D(width, height, TextureFormat.RGB24, false);
        Color32[] alphaPixels = new Color32[pixels.Length];

        for (int i = 0; i < pixels.Length; i++)
        {
            byte a = pixels[i].a;
            alphaPixels[i] = new Color32(a, a, a, 255);
        }

        alphaTex.SetPixels32(alphaPixels);
        alphaTex.Apply();

        string directory = Path.GetDirectoryName(path);
        string fileName = Path.GetFileNameWithoutExtension(path);

        File.WriteAllBytes(
            Path.Combine(directory, fileName + "_Alpha.tga"),
            alphaTex.EncodeToTGA()
        );

        Debug.Log("Alpha separado com sucesso!");
        AssetDatabase.Refresh();
    }
}