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

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().isTrigger = true;

        transform.localScale = new Vector3(Collision_Width, Collision_Height, Collision_Length);

        try
        {
            target = FindObjectByID(Target).gameObject;
        }
        catch
        {

        }

    }

    public void Start()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().isTrigger = true;

        transform.localScale = new Vector3(Collision_Width, Collision_Height, Collision_Length);

        try
        {
            target = FindObjectByID(Target).gameObject;
        }
        catch
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            try
            {
                target.SendMessage("EaseTimeEnter", Ease_Time_Enter, SendMessageOptions.DontRequireReceiver);
                target.SendMessage("EaseTimeLeave", Ease_Time_Leave, SendMessageOptions.DontRequireReceiver);

                if (!GameManager.instance.cameras.Contains(target))
                {
                    try
                    {
                        GameManager.instance.cameras.Insert(0, target);
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            if (GameManager.instance.cameras.Count > 0)
            {
                try
                {
                    GameManager.instance.cameras.Remove(target);
                }
                catch
                {

                }
            }

        }
    }

    private void OnDestroy()
    {
        if (GameManager.instance.cameras.Count > 0)
        {
            try
            {
                GameManager.instance.cameras.Remove(target);
            }
            catch
            {

            }
        }
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