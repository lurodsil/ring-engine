using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RingEngineObject), true)]
[CanEditMultipleObjects]
public class RingEngineObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RingEngineObject ringEngineObject = (RingEngineObject)target;
        ringEngineObject.active = EditorGUILayout.Toggle("Active", ringEngineObject.active);

        DrawDefaultInspector();

        SerializedProperty onBecomeActive = serializedObject.FindProperty("OnBecomeActive");
        SerializedProperty onBecomeInactive = serializedObject.FindProperty("OnBecomeInactive");

        ringEngineObject.showEventsInInspector = EditorGUILayout.Foldout(ringEngineObject.showEventsInInspector, "Events");

        if (ringEngineObject.showEventsInInspector)
        {
            EditorGUILayout.PropertyField(onBecomeActive);
            EditorGUILayout.PropertyField(onBecomeInactive);
        }

        serializedObject.ApplyModifiedProperties();
    }
}