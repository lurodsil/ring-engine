using UnityEngine;
using UnityEditor;

public class MultiMaterialRemap
{
    [MenuItem("Tools/Materials/Search And Remap (Selected Models)")]
    static void RemapSelectedModels()
    {
        Object[] selected = Selection.objects;

        int count = 0;

        foreach (Object obj in selected)
        {
            string path = AssetDatabase.GetAssetPath(obj);

            if (string.IsNullOrEmpty(path))
                continue;

            ModelImporter importer = AssetImporter.GetAtPath(path) as ModelImporter;

            if (importer == null)
                continue;

            Undo.RecordObject(importer, "Search and Remap Materials");

            // Equivalente ao:
            // Naming = By Base Texture Name
            // Search = Recursive-Up
            importer.SearchAndRemapMaterials(
                ModelImporterMaterialName.BasedOnTextureName,
                ModelImporterMaterialSearch.RecursiveUp
            );

            importer.SaveAndReimport();

            count++;
        }

        Debug.Log($"Remapped {count} model(s)");
    }
}