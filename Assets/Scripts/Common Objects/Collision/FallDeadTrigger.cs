using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class FallDeadTrigger : CommonStatefulObject
{
    public bool drownPlayer = false;

    public void Start()
    {
        objectState = StateFallDead;

        OnPlayerTriggerEnter.RemoveAllListeners();

        OnPlayerTriggerEnter.AddListener(KillPlayer);
        OnPlayerTriggerEnter.AddListener(ChangeState);    
    }

    #region State Fall Dead
    void StateFallDeadStart()
    {
        OnStateStart?.Invoke();

        CameraManager.DeactivateAllCameras();

        MainCamera.SetActive(false);

        Timer.PauseTimer();
    }
    void StateFallDead()
    {
        if (drownPlayer)
        {
            player.rigidbody.velocity *= 0.9f;
        }

        if (Time.time > player.stateMachine.lastStateTime + 2)
        {
            GameManager.instance.lives--;
            GameManager.instance.ReloadSceneWithLoading();
        }
    }
    void StateFallDeadEnd()
    {
        OnStateEnd?.Invoke();
    }
    #endregion

    private void KillPlayer()
    {
        player.drown = drownPlayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        GizmosExtension.DrawBoxBoundaries(GetComponent<BoxCollider>());
    }
}