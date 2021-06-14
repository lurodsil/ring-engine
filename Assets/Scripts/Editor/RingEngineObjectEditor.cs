using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RingEngineObject),true)]
public class RingEngineObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RingEngineObject ringEngineObject = (RingEngineObject)target;
        ringEngineObject.active = EditorGUILayout.Toggle("Active", ringEngineObject.active);
        DrawDefaultInspector();
    }
}