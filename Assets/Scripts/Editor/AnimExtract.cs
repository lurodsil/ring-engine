using System.IO;
using UnityEditor;
using UnityEngine;

public class AnimExtract : EditorWindow
{
    string sourcePath = "Assets/Input/";
    string destinationPath = "Assets/Output/";
    string log = string.Empty;

    [MenuItem("Window/Ring Engine Tools/FBX to Animation")]
    public static void ShowWindow()
    {
        GetWindow(typeof(AnimExtract), true);
    }

    void OnGUI()
    {
        EditorGUILayout.HelpBox("AnimExtract extracts the animation from a .fbx file, " +
            "and save as Unity native .anim. For better results, " +
            "please setup the animation duration and events before the conversion.", MessageType.Info);

        EditorGUILayout.Separator();

        EditorGUILayout.BeginHorizontal();

        sourcePath = EditorGUILayout.TextField(".fbx source folder", sourcePath);

        if (GUILayout.Button("Browse"))
        {
            sourcePath = "Assets" + EditorUtility.OpenFolderPanel(title, "/Assets", "").Replace(Application.dataPath, "");
            destinationPath = sourcePath + "/Output/";
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        destinationPath = EditorGUILayout.TextField(".anim destination folder", destinationPath);

        if (GUILayout.Button("Browse"))
        {
            destinationPath = "Assets" + EditorUtility.OpenFolderPanel(title, "/Assets", "").Replace(Application.dataPath, "");
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Convert"))
        {
            sourcePath = CheckIfPathIsCorrect(sourcePath);
            destinationPath = CheckIfPathIsCorrect(destinationPath);

            if (ValidadePath(sourcePath))
            {
                ConvertAnimationClips(sourcePath, destinationPath);
            }
        }

        EditorGUILayout.HelpBox(log,MessageType.None);
    }

    private string CheckIfPathIsCorrect(string path)
    {
        if (!path.EndsWith("/"))
        {
            path += "/";
        }

        return path;
    }

    private bool ValidadePath(string path)
    {
        if (Directory.Exists(path))
        {
            return true;
        }
        else
        {
            EditorUtility.DisplayDialog("Folder not found", path + " does not exist!", "OK");

            return false;
        }
    }

    private void CheckAndCreateOutputDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    void ConvertAnimationClips(string sourceDirectory, string destinationDirectory)
    {
        log = string.Empty;

        CheckAndCreateOutputDirectory(destinationDirectory);

        string[] sourceClips = Directory.GetFiles(sourceDirectory, "*.fbx", SearchOption.AllDirectories);

        float clipPercentage = 100 / sourceClips.Length;

        float progress = 0;        

        for (int i = 0; i < sourceClips.Length; i++)
        {
            string sourceFBXName = Path.GetFileNameWithoutExtension(sourceClips[i]);
            string sourceFBXPath = sourceDirectory + sourceFBXName + ".fbx";
            string destinationAnimationPath = destinationDirectory + sourceFBXName + ".anim";

            if (File.Exists(destinationAnimationPath))
            {
                if (EditorUtility.DisplayDialog("File exists", sourceFBXName + ".anim already exists in the destination directory.\r\n" +
                    "Do you want do overwrite file?", "Yes", "No"))
                {
                    File.Delete(destinationAnimationPath);
                }
                else
                {
                    log += "Ignoring file " + destinationAnimationPath + "\r\n";
                    break;
                }
            }

            AnimationClip sourceClip = (AnimationClip)AssetDatabase.LoadAssetAtPath(sourceFBXPath, typeof(AnimationClip));

            SerializedObject serializedClip = new SerializedObject(sourceClip);

            serializedClip.ApplyModifiedProperties();

            AnimationClip destinationClip = new AnimationClip();

            EditorUtility.CopySerialized(sourceClip, destinationClip);

            AssetDatabase.CreateAsset(destinationClip, destinationAnimationPath);

            log += "Successfull converted file " + destinationAnimationPath + "\r\n";

            AssetDatabase.Refresh();

            progress += clipPercentage;

            EditorUtility.DisplayProgressBar("Converting", "Converting to .anim", progress);
        }

        EditorUtility.ClearProgressBar();

        EditorUtility.DisplayDialog("Success!", sourceClips.Length + " animation successfully converted.", "OK");
    }
}