using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Save Settings"))
        {
            FileManager.Save(gameManager.settings, gameManager.settingsPath);
        }

        if (GUILayout.Button("Load Settings"))
        {
            gameManager.settings = FileManager.Load(gameManager.settings, gameManager.settingsPath);
        }

        if (GUILayout.Button("Show"))
        {
            gameManager.achievementUI.Show(Achievements.achievements[1], gameManager.settings.languageType);
        }
    }
}
