using System.IO;
using UnityEditor;
using UnityEngine;

public class AnimExtract : EditorWindow
{

    string inputFbx = "Assets/Input/";
    string outputAnim = "Assets/Output/";

    [MenuItem("Ring Engine/Anim Extract")]
    public static void ShowWindow()
    {
        GetWindow(typeof(AnimExtract), true);
    }

    void OnEnable()
    {
        if (!Directory.Exists(inputFbx))
        {
            EditorUtility.DisplayDialog("Input folder not found!", "The default input folder (Assets/Input/) was not found. Please assign the folder who contains .fbx files.", "OK");
        }
        if (!Directory.Exists(outputAnim))
        {
            Directory.CreateDirectory(outputAnim);
            AssetDatabase.Refresh();
        }
    }

    void OnGUI()
    {
        EditorGUILayout.HelpBox("AnimExtract extracts the animation from a .fbx file, " +
            "and save as Unity native .anim. For better results, " +
            "please setup the animation duration and events before the conversion.", MessageType.Info);

        EditorGUILayout.Separator();

        inputFbx = EditorGUILayout.TextField(".fbx source folder", inputFbx);

        outputAnim = EditorGUILayout.TextField(".anim destination folder", outputAnim);

        if (GUILayout.Button("Convert"))
        {
            CreateAnimationClips();
        }
    }

    void CreateAnimationClips()
    {
        float progress = 0;

        int index = 0;

        string[] clips = Directory.GetFiles(inputFbx, "*.fbx", SearchOption.AllDirectories);

        float clipPercentage = 100 / clips.Length;

        foreach (string s in clips)
        {

            string name = Path.GetFileNameWithoutExtension(s);

            if ((AnimationClip)AssetDatabase.LoadAssetAtPath(inputFbx + name + ".fbx", typeof(AnimationClip)))
            {

                AnimationClip originalClip = (AnimationClip)AssetDatabase.LoadAssetAtPath(inputFbx + name + ".fbx", typeof(AnimationClip));

                SerializedObject serializedClip = new SerializedObject(originalClip);

                serializedClip.ApplyModifiedProperties();

                AnimationClip newClip = new AnimationClip();

                if (!File.Exists(outputAnim + name + ".anim"))
                {
                    EditorUtility.CopySerialized(originalClip, newClip);

                    AssetDatabase.CreateAsset(newClip, outputAnim + name + ".anim");

                    AssetDatabase.Refresh();

                    index++;
                }

                progress += clipPercentage;

                EditorUtility.DisplayProgressBar("Converting", "Converting to .anim", progress);
            }
        }

        EditorUtility.ClearProgressBar();

        if (index > 0)
        {
            EditorUtility.DisplayDialog("Success!", index + " animation successfully converted.", "OK");
        }
        else
        {
            EditorUtility.DisplayDialog("Warning!", "The animations who you are trying to convert already exists in the output directory." +
                " Change the name of the input animation or delete the destination animation.", "OK");
        }
    }
}