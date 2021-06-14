using UnityEngine;

[RequireComponent(typeof(BezierSpline))]
public class LightSpeedDashChain : MonoBehaviour
{
    public GameObject ring;
    public float maxDistance = 1;
    public float precision = 0.001f;
    private BezierSpline bezierSpline;

    public void CleanChain()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    public void CreateChain(GameObject prefab, float maxDistance, float precision = 0.001f)
    {
        CleanChain();

        if (prefab == null)
        {
            Debug.LogWarning("Please setup the ring prefab before creating the chain!");
            return;
        }

        bezierSpline = GetComponent<BezierSpline>();

        Vector3 lastPoint = new Vector3();

        gameObject.name = "LightSpeedDashChain";

        Instantiate(ring, bezierSpline.GetPoint(0), Quaternion.identity, transform).GetComponent<Ring>().IsLightSpeedDashTarget = true;

        for (float f = 0; f < 1; f += precision)
        {
            Vector3 point = bezierSpline.GetPoint(f);

            if (Vector3.Distance(point, lastPoint) > maxDistance)
            {
                Instantiate(ring, point, Quaternion.identity, transform).GetComponent<Ring>().IsLightSpeedDashTarget = true;

                lastPoint = point;
            }
        }

        Instantiate(ring, bezierSpline.GetPoint(1), Quaternion.identity, transform).GetComponent<Ring>().IsLightSpeedDashTarget = true;
    }
}
