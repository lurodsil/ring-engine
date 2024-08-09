using UnityEngine;

public class AutorunFinishCollision : CommonObject
{
    public bool removePlayerPath = false;
    private void Start()
    {
        OnPlayerTriggerEnter.AddListener(AutorunFinish);
        gameObject.SetActive(false);
    }

    private void AutorunFinish()
    {
        player.autorunVelocity = 0;
        gameObject.SetActive(false);

        if (removePlayerPath)
        {
            player.sideViewPath = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(.5f, 0, .5f, 0.5f);
        GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
    }
}