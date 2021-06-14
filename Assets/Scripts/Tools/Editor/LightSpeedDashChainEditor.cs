using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LightSpeedDashChain))]
public class LightSpeedDashChainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LightSpeedDashChain lightSpeedDashChain = (LightSpeedDashChain)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create Chain"))
        {
            lightSpeedDashChain.CreateChain(lightSpeedDashChain.ring, lightSpeedDashChain.maxDistance, lightSpeedDashChain.precision);
        }

        if (GUILayout.Button("Clean Chain"))
        {
            lightSpeedDashChain.CleanChain();
        }

    }
}
