using UnityEngine;

public class NavigationCollision : CommonObject
{

    public float CancelAngle = 90f;
    public float CollisionType = 1f;
    public float Collision_Height = 11f;
    public float Collision_Length = 48f;
    public float Collision_Width = 15f;
    public float DefaultStatus = 0f;
    public float DelayTime = 7f;
    public float DelayType = 0f;
    public float DirectionType = 0f;

    public float InputAngle = 70f;

    public float NavigationType = 2f;
    public float OffSpeed = 5f;
    public float OnSpeed = 5f;
    public float OutputTime = 3f;
    public float QSType = 0f;

    public Vector3 SlidingPosition;
    public int TargetObject_RelationSetObject;
    public XboxButton button;

    public Transform worldPosition;

    public void OnValidate()
    {
        transform.localScale = new Vector3(Collision_Width, Collision_Height, Collision_Length);

        gameObject.GetComponent<BoxCollider>().isTrigger = true;


    }

    private void Start()
    {
        base.OnPlayerTriggerEnter.AddListener(OnPlayerTriggerEnter);
        base.OnPlayerTriggerExit.AddListener(OnPlayerTriggerExit);
    }

    private new void OnPlayerTriggerEnter()
    {
        //GameplayUI.instance.ShowAplusX();

        if (!worldPosition)
        {
            if (button == XboxButton.None)
            {
                GameplayUI.instance.ShowAplusX();
            }
            else
            {
                GameplayUI.instance.ShowButton(button);
            }
        }
        else
        {
            GameplayUI.instance.ShowButton(button, worldPosition.position);
        }
    }

    private new void OnPlayerTriggerExit()
    {
        GameplayUI.instance.HideButton();

        GameplayUI.instance.HideAplusX();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(SlidingPosition, 0.3f);
    }
}