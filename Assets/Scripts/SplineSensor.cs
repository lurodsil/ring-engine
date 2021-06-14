using UnityEngine;

public class SplineSensor : MonoBehaviour
{
    public BezierPath bezierPath;

    private void OnTriggerStay(Collider other)
    {
        if (!bezierPath)
        {
            if (other.GetComponent<BezierPath>())
            {
                bezierPath = other.GetComponent<BezierPath>();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bezierPath = null;
    }
}
