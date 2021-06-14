using UnityEngine;

public class NavigationCollision : GenerationsObject
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

    public override void OnValidate()
    {
        transform.localScale = new Vector3(Collision_Width, Collision_Height, Collision_Length);

        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SlidingPosition == Vector3.zero)
        {
            GameplayUI.instance.ShowButton(button);
        }
        else
        {
            GameplayUI.instance.ShowButton(button, SlidingPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameplayUI.instance.HideButton();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(SlidingPosition, 0.3f);
    }
}