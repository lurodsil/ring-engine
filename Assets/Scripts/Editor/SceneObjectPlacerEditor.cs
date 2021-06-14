using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneObjectPlacer))]
public class SceneObjectPlacerEditor : Editor
{
    SceneObjectPlacer sceneObjectPlacer;

    void OnEnable()
    {
        sceneObjectPlacer = (SceneObjectPlacer)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }

    private void OnSceneGUI()
    {
        sceneObjectPlacer = (SceneObjectPlacer)target;

        SceneView scene = SceneView.currentDrawingSceneView;

        Event e = Event.current;

        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.C)
        {
            Vector3 mousePos = e.mousePosition;
            float ppp = EditorGUIUtility.pixelsPerPoint;
            mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
            mousePos.x *= ppp;

            Ray ray = scene.camera.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject go = Instantiate(sceneObjectPlacer.prefab, sceneObjectPlacer.transform);

                go.transform.position = hit.point;

                if (sceneObjectPlacer.randomRotation)
                {
                    go.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                }

                if (sceneObjectPlacer.alignWithNormal)
                {
                    go.transform.rotation = Quaternion.FromToRotation(go.transform.up, hit.normal) * go.transform.rotation;
                }
            }
            e.Use();
        }

    }
}