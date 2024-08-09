using UnityEngine;

public class ChangePathCollision : CommonObject
{
    public BezierPath path;

    private void Start()
    {
        OnPlayerTriggerEnter!.AddListener(ChangePath);
    }

    public void ChangePath()
    {
        player.sideViewPath = path;        
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Tornado"))
        {
            other.GetComponent<Tornado>().path = path;
        }
    }
}