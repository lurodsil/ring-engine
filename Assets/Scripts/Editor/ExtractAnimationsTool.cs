using UnityEngine;
using UnityEditor;
using System.IO;

public class ExtractAnimationsTool
{
    [MenuItem("Assets/Extract Animations", true)]
    static bool ValidateExtract()
    {
        foreach (Object obj in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(obj);

            if (Path.GetExtension(path).ToLower() == ".fbx")
                return true;
        }

        return false;
    }

    [MenuItem("Assets/Extract Animations")]
    static void ExtractAnimations()
    {
        Object[] selected = Selection.objects;

        int total = selected.Length;
        int index = 0;

        try
        {
            foreach (Object obj in selected)
            {
                string path = AssetDatabase.GetAssetPath(obj);

                if (Path.GetExtension(path).ToLower() != ".fbx")
                    continue;

                index++;

                float progress = (float)index / total;

                EditorUtility.DisplayProgressBar(
                    "Extracting Animations",
                    obj.name,
                    progress
                );

                ExtractFromFBX(path);
            }
        }
        finally
        {
            EditorUtility.ClearProgressBar();
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Extraction finished!");
    }

    static void ExtractFromFBX(string path)
    {
        string folder = Path.GetDirectoryName(path);
        string fbxName = Path.GetFileNameWithoutExtension(path);

        bool loop = fbxName.ToLower().Contains("loop");

        Object[] assets = AssetDatabase.LoadAllAssetsAtPath(path);

        foreach (Object asset in assets)
        {
            if (!(asset is AnimationClip clip))
                continue;

            if (clip.name.StartsWith("__preview__"))
                continue;

            AnimationClip newClip = Object.Instantiate(clip);

            if (loop)
            {
                SerializedObject so = new SerializedObject(newClip);
                SerializedProperty settings = so.FindProperty("m_AnimationClipSettings");

                settings.FindPropertyRelative("m_LoopTime").boolValue = true;

                so.ApplyModifiedProperties();
            }

            AnimationEvent[] events = AnimationUtility.GetAnimationEvents(clip);

            if (events != null && events.Length > 0)
            {
                AnimationUtility.SetAnimationEvents(newClip, events);
            }
            string savePath = Path.Combine(folder, fbxName + ".anim");
            savePath = AssetDatabase.GenerateUniqueAssetPath(savePath);

            AssetDatabase.CreateAsset(newClip, savePath);
        }
    }
}