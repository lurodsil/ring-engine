using UnityEngine;

public class BillboardMesh : MonoBehaviour
{
    public enum RenderMode
    {
        Billboard,
        VerticalBillboard
    }

    public RenderMode renderMode;

    Vector3 targetPosition;

    void LateUpdate()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        switch (renderMode)
        {
            case RenderMode.Billboard: targetPosition = cameraPosition; break;
            case RenderMode.VerticalBillboard: targetPosition = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z); break;
        }

        transform.LookAt(targetPosition);
    }
}
