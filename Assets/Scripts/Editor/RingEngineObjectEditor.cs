using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RingEngineObject), true)]
[CanEditMultipleObjects]
public class RingEngineObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RingEngineObject ringEngineObject = (RingEngineObject)target;

        EditorGUI.BeginChangeCheck();

        ringEngineObject.active = EditorGUILayout.Toggle("Active", ringEngineObject.active);           

        DrawDefaultInspector();

        SerializedProperty onStateStart = serializedObject.FindProperty("OnStateStart");
        SerializedProperty onStateEnd = serializedObject.FindProperty("OnStateEnd");
        SerializedProperty onBecomeActive = serializedObject.FindProperty("OnBecomeActive");
        SerializedProperty onBecomeInactive = serializedObject.FindProperty("OnBecomeInactive");

        ringEngineObject.showEventsInInspector = EditorGUILayout.Foldout(ringEngineObject.showEventsInInspector, "Events");

        if (ringEngineObject.showEventsInInspector)
        {
            EditorGUILayout.PropertyField(onStateStart);
            EditorGUILayout.PropertyField(onStateEnd);
            EditorGUILayout.PropertyField(onBecomeActive);
            EditorGUILayout.PropertyField(onBecomeInactive);
        }

        serializedObject.ApplyModifiedProperties();

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(target);
            PrefabUtility.RecordPrefabInstancePropertyModifications(target);
        }
        
    }
    
}