using UnityEngine;

[ExecuteInEditMode]
public class Wire : MonoBehaviour
{

    public BezierSpline spline;
    public Transform pulleyStart, pulleyEnd;
    private Vector3 offset = new Vector3(0, -2.5f, 0);

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        pulleyStart.position = spline.GetPoint(0) + offset;
        pulleyStart.forward = spline.GetTangent(0);

        pulleyEnd.position = spline.GetPoint(1) + offset;
        pulleyEnd.forward = spline.GetTangent(1);

        float step = 1f / 20;

        for (int i = 0; i < 21; i++)
        {
            transform.GetChild(i).position = spline.GetPoint(step * i);
            transform.GetChild(i).forward = spline.GetTangent(step * i);
        }
    }

    private void Reset()
    {


    }

}
