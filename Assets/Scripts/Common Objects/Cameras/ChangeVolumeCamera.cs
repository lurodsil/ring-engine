using UnityEngine;

public class ChangeVolumeCamera : GenerationsObject
{
    public float Collision_Height = 10f;
    public float Collision_Length = 10f;
    public float Collision_Width = 10f;
    public float Ease_Time_Enter = 0.5f;
    public float Ease_Time_Leave = 1f;
    public int Target;
    public float Priority = 0f;
    public float DefaultStatus = 0f;
    public bool IsCameraView = false;
    public bool IsEnableCollision = false;
    public float LineType = 0f;
    public float Shape_Type = 0f;

    public GameObject target;


    private void Start()
    {
        if (!target)
        {
            try
            {
                target = FindObjectByID(Target).gameObject;
            }
            catch
            {

            }
        }      

    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            target.SendMessage("EaseTimeEnter", Ease_Time_Enter, SendMessageOptions.DontRequireReceiver);
            target.SendMessage("EaseTimeLeave", Ease_Time_Leave, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            CameraManager.cameras[(int)Priority] = target;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            CameraManager.cameras[(int)Priority] = null;
        }
    }

    private void OnDestroy()
    {
        CameraManager.cameras[(int)Priority] = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        try
        {
            Gizmos.DrawLine(transform.position, FindObjectByID(Target).transform.position);
        }
        catch
        {

        }
    }
}