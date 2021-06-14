using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetsImportSettings : AssetPostprocessor
{
    void OnPreprocessAnimation()
    {
        ModelImporter importer = assetImporter as ModelImporter;
        //Model
        importer.materialName = ModelImporterMaterialName.BasedOnTextureName;
        //importer.materialSearch = ModelImporterMaterialSearch.RecursiveUp;
        //Animations
        //importer.animationCompression = ModelImporterAnimationCompression.Off;

        ModelImporterClipAnimation[] animations = importer.defaultClipAnimations;

        Debug.Log(importer.clipAnimations.Length);

        for (int i = 0; i < animations.Length; i++)
        {
            string name = Path.GetFileNameWithoutExtension(importer.assetPath);
            animations[i].name = name;
            if (name.Contains("_loop"))
            {
                animations[i].loopTime = true;
            }
        }

        importer.clipAnimations = animations;
    }
}

