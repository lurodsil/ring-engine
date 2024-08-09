
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AutorunStartCollision : CommonObject
{
    public float velocity = 30;
    public bool triggerOnce = false;
    public BezierPath bezierPath;
    public AutorunFinishCollision autorunFinishCollision;

    public void Start()
    {
        OnPlayerTriggerEnter.AddListener(AutorunStart);
    }

    private void AutorunStart()
    {
        if (player.sideViewPath == null)
        {
            player.sideViewPath = bezierPath;
            autorunFinishCollision.removePlayerPath = true;
        }
        else
        {
            autorunFinishCollision.removePlayerPath = false;
        }

        player.autorunVelocity = velocity;
        autorunFinishCollision.gameObject.SetActive(true);
        if (triggerOnce)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(.5f, 0, .5f, 0.5f);
        GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
    }
}