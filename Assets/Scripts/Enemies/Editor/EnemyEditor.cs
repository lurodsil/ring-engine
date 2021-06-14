using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    int id;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    protected virtual void OnSceneGUI()
    {
        Enemy enemy = (Enemy)target;

        Handles.ConeHandleCap(id, enemy.transform.position, enemy.transform.rotation, enemy.viewAngle, EventType.DragPerform);
    }
}
