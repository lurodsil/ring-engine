using UnityEngine;

public struct FrenetFrame
{
    public Vector3 point;
    public Vector3 tangent;
    public Vector3 normal;
    public Vector3 binormal;
    public float t;

    public Quaternion rotation
    {
        get
        {
            return Quaternion.LookRotation(tangent, normal);
        }
    }

    public FrenetFrame(Vector3 point, Vector3 tangent, Vector3 normal, float t)
    {
        this.point = point;

        this.tangent = tangent.normalized;
        this.normal = normal.normalized;

        this.binormal = Vector3.Cross(this.normal, this.tangent).normalized;
        this.normal = Vector3.Cross( this.tangent, this.binormal).normalized;

        this.t = t;
    }
}