using UnityEngine;

public class RainbowRing : GenerationsObject
{

    public float FirstSpeed = 35f;


    public bool IsChangeCameraWhenChangePath = false;
    public bool IsChangePath = false;
    public bool IsHeadToVelocity = true;
    public bool IsTo3D = false;
    public float KeepVelocityDistance = 5f;
    public float OutOfControl = 1.5f;
    public float trajectoryLength = 1;

    public override void OnValidate()
    {

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (-transform.forward * KeepVelocityDistance));
        GizmosExtension.DrawTrajectory(transform.position + (-transform.forward * KeepVelocityDistance), -transform.forward, FirstSpeed, trajectoryLength);

        //Gizmos.DrawSphere(m_MonkeyTarget, 0.2f);


        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (-transform.forward * KeepVelocityDistance));
        GizmosExtension.DrawTrajectory(transform.position + (-transform.forward * KeepVelocityDistance), -transform.forward, FirstSpeed, OutOfControl - PhysicsExtension.Time(KeepVelocityDistance, FirstSpeed));

    }
}