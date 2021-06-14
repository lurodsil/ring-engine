using UnityEngine;

public class CameraCollisionBoard : GenerationsObject
{
    public int ACameraID;

    public float ACameraPriority = 0f;
    public int ALinkObjID;
    public float ALinkSide = 1f;
    public float AObjType = 0f;
    public int BCameraID;
    public float BCameraPriority = 0f;
    public int BLinkObjID;
    public float BLinkSide = 0f;
    public float BObjType = 0f;
    public float Collision_Height = 10f;
    public float Collision_Width = 10f;
    public float EaseTime_AtoB = 1f;
    public float EaseTime_BtoA = 1f;
    public float m_ValidFlag = 0f;

    public GameObject aCamera;
    public GameObject bCamera;

    GameObject target;

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }

        gameObject.GetComponent<BoxCollider>().isTrigger = true;

        transform.localScale = new Vector3(Collision_Width, Collision_Height, 1f);

        try
        {
            aCamera = FindObjectByID(ACameraID).gameObject;
            bCamera = FindObjectByID(BCameraID).gameObject;
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
                float dot = Vector3.Dot(transform.forward, other.transform.forward);

                if (dot < 0)
                {
                    if (ACameraID == 0)
                    {
                        GameManager.instance.cameras.Clear();
                    }

                    target = aCamera;

                    GameManager.instance.cameras.Clear();

                    target.SendMessage("EaseTimeEnter", EaseTime_BtoA, SendMessageOptions.DontRequireReceiver);

                    target.SendMessage("Strt()", SendMessageOptions.DontRequireReceiver);

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
                else
                {
                    if (BCameraID == 0)
                    {
                        GameManager.instance.cameras.Clear();
                    }

                    target = bCamera;

                    GameManager.instance.cameras.Clear();

                    target.SendMessage("EaseTimeEnter", EaseTime_AtoB, SendMessageOptions.DontRequireReceiver);
                    target.SendMessage("Strt()", SendMessageOptions.DontRequireReceiver);

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
            Gizmos.DrawLine(transform.position, FindObjectByID(ACameraID).transform.position);
        }
        catch
        {

        }
        Gizmos.color = Color.Lerp(Color.green, Color.black, 0.5f);

        try
        {
            Gizmos.DrawLine(transform.position, FindObjectByID(ALinkObjID).transform.position);
        }
        catch
        {

        }

        Gizmos.color = Color.blue;
        try
        {
            Gizmos.DrawLine(transform.position, FindObjectByID(BCameraID).transform.position);
        }
        catch
        {

        }
        Gizmos.color = Color.cyan;
        try
        {
            Gizmos.DrawLine(transform.position, FindObjectByID(BLinkObjID).transform.position);
        }
        catch
        {

        }
    }
}