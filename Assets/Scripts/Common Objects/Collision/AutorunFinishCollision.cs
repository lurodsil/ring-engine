using UnityEngine;

public class AutorunFinishCollision : GenerationsObject
{
    public float Collision_Height = 30f;
    public float Collision_Width = 10f;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public override void OnValidate()
    {
        if (!gameObject.GetComponent<BoxCollider>())
        {
            BoxCollider collider = gameObject.AddComponent<BoxCollider>();

            collider.isTrigger = true;
        }
        else
        {
            BoxCollider collider = gameObject.GetComponent<BoxCollider>();

            collider.isTrigger = true;
        }

        transform.localScale = new Vector3(Collision_Width, Collision_Height, 1);
    }

    private void OnPlayerTriggerEnter()
    {
        if (player.stateMachine.currentStateName == "StateAutorun")
        {
            player.velocity = 44;
            gameObject.SetActive(false);
        }
    }
}