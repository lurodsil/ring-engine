using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : CommonActivableStatelessObject
{
    [SerializeField] float cutsceneDutarion = 5;
    [SerializeField] bool lockPlayerControls = true;
    [SerializeField] Transform playerPositionAfterCutscene;

    [SerializeField] bool smoothTransition;
    [SerializeField] AnimationCurve animationCurve = AnimationCurve.EaseInOut(0,0,1,1);
   
    [SerializeField] float positionEaseIn = 5f;
    [SerializeField] float rotationEaseIn = 5f;
    [SerializeField] float fieldOfViewEaseIn = 2f;
    [SerializeField] float fieldOfView = 60f;

    [SerializeField] bool returnToStartPosition;

    [SerializeField] Transform cameraTargetPosition;

    private Vector3 cameraPositionBeforeCutscene;
    private Quaternion cameraRotationBeforeCutscene;

    private float cutsceneStartTime;
    private float fieldOfViewBeforeCutscene;

    private bool mainCameraEnabled;

    private void Update()
    {
        if (active)
        {
            if (smoothTransition)
            {
                Camera.main.fieldOfView = Mathf.Lerp(fieldOfViewBeforeCutscene, fieldOfView, animationCurve.Evaluate((Time.time - cutsceneStartTime) / fieldOfViewEaseIn));
                Camera.main.transform.position = Vector3.Lerp(cameraPositionBeforeCutscene, cameraTargetPosition.position, animationCurve.Evaluate((Time.time - cutsceneStartTime) / positionEaseIn));
                Camera.main.transform.rotation = Quaternion.Lerp(cameraRotationBeforeCutscene, cameraTargetPosition.rotation, animationCurve.Evaluate((Time.time - cutsceneStartTime) / rotationEaseIn));
            }
            else
            {
                Camera.main.transform.position = cameraTargetPosition.position;
                Camera.main.transform.rotation = cameraTargetPosition.rotation;
            }

            if(Time.time > cutsceneStartTime + cutsceneDutarion)
            {
                Deactivate();
            }
        }
    }

    public void CutsceneStart()
    {


        cutsceneStartTime = Time.time;

        GameManager.instance.gameState = GameState.Cutscene;
        cameraPositionBeforeCutscene = Camera.main.transform.position;
        cameraRotationBeforeCutscene = Camera.main.transform.rotation;
        fieldOfViewBeforeCutscene = Camera.main.fieldOfView;

        mainCameraEnabled = MainCamera.IsEnabled();

        MainCamera.SetActive(false);

        player.rigidbody.velocity = Vector3.zero;
        if (lockPlayerControls)
        {
            player.stateMachine.Pause();
        }

        
    }

    public void CutsceneEnd()
    {
        MainCamera.ReturnFromCutscene(returnToStartPosition);

        MainCamera.SetActive(mainCameraEnabled);
        Camera.main.fieldOfView = fieldOfViewBeforeCutscene;

        GameManager.instance.gameState = GameState.Playing;
        player.stateMachine.Play();

        if (returnToStartPosition)
        {
            Camera.main.transform.position = cameraPositionBeforeCutscene;
            Camera.main.transform.rotation = cameraRotationBeforeCutscene;
        }        
    }
}
