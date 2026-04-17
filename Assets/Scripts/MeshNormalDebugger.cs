using UnityEngine;

[ExecuteAlways]
public class MeshNormalDebugger : MonoBehaviour
{
    public float normalLength = 0.3f;
    public bool drawOnlySelected = true;
    public bool colorByUpDirection = true;

    void OnDrawGizmos()
    {
        if (drawOnlySelected && !IsSelected())
            return;

        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null)
            return;

        Mesh mesh = mf.sharedMesh;

        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        Matrix4x4 localToWorld = transform.localToWorldMatrix;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 v0 = vertices[triangles[i]];
            Vector3 v1 = vertices[triangles[i + 1]];
            Vector3 v2 = vertices[triangles[i + 2]];

            // Centro da face
            Vector3 centerLocal = (v0 + v1 + v2) / 3f;
            Vector3 centerWorld = localToWorld.MultiplyPoint3x4(centerLocal);

            // Normal da face (cross product)
            Vector3 edge1 = v1 - v0;
            Vector3 edge2 = v2 - v0;
            Vector3 normalLocal = Vector3.Cross(edge1, edge2).normalized;
            Vector3 normalWorld = localToWorld.MultiplyVector(normalLocal).normalized;

            if (colorByUpDirection)
            {
                float dot = Vector3.Dot(normalWorld, Vector3.up);
                Gizmos.color = Color.Lerp(Color.red, Color.green, (dot + 1f) * 0.5f);
            }
            else
            {
                Gizmos.color = Color.cyan;
            }

            Gizmos.DrawLine(centerWorld, centerWorld + normalWorld * normalLength);
        }
    }

    bool IsSelected()
    {
#if UNITY_EDITOR
        return UnityEditor.Selection.activeGameObject == gameObject;
#else
        return true;
#endif
    }
}

