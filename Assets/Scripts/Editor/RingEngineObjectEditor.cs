using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(RingEngineObject), true)]
[CanEditMultipleObjects]
public class RingEngineObjectEditor : Editor
{
    bool showEventsInInspector;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SerializedProperty onStateStart = serializedObject.FindProperty("OnStateStart");
        SerializedProperty onStateEnd = serializedObject.FindProperty("OnStateEnd");
        SerializedProperty onBecomeActive = serializedObject.FindProperty("OnBecomeActive");
        SerializedProperty onBecomeInactive = serializedObject.FindProperty("OnBecomeInactive");

        showEventsInInspector = EditorGUILayout.Foldout(showEventsInInspector, "Events");

        if (showEventsInInspector)
        {
            EditorGUILayout.PropertyField(onStateStart);
            EditorGUILayout.PropertyField(onStateEnd);
            EditorGUILayout.PropertyField(onBecomeActive);
            EditorGUILayout.PropertyField(onBecomeInactive);
        }

        serializedObject.ApplyModifiedProperties();
    }
}