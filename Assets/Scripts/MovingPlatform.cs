using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform pointA, pointB;
    public float velocity = 0.3f;
    public float angularVelocity = 0;
    public AnimationCurve movementCurve;

    void Update()
    {
        platform.localPosition = Vector3.Lerp(pointA.localPosition, pointB.localPosition, movementCurve.Evaluate(Mathf.PingPong(Time.time * velocity, 1)));
        platform.Rotate(0, angularVelocity * Time.deltaTime, 0);
    }

    private void Reset()
    {
        Keyframe[] keys = new Keyframe[3];

        keys[0].time = 0;
        keys[0].value = 0.1f;

        keys[1].time = 0.5f;
        keys[1].value = 1f;

        keys[2].time = 1;
        keys[2].value = 0.1f;

        movementCurve = new AnimationCurve(keys);

        pointA = transform.Find("PointA");
        pointB = transform.Find("PointB");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
