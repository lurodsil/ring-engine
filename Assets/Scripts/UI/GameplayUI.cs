using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{

    public static GameplayUI instance;
    public Image cameraBlock;
    public Image buttonA, buttonB, buttonX, buttonY;
    public GameObject buttonLBRB;
    public GameObject leftStick;
    public AudioClip buttonShow;
    private AudioSource audioSource;
    private Vector3 worldPosition;
    private Image activeButton;
    public GameObject aPlusX;

    // Use this for initialization
    void Start()
    {
        instance = GetComponent<GameplayUI>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraBlock.enabled = CameraManager.GetCameraCount() > 0;

        if (worldPosition != Vector3.zero)
        {

            activeButton.rectTransform.position = Camera.main.WorldToScreenPoint(worldPosition);

        }
    }

    public void ShowButton(XboxButton button)
    {
        audioSource.PlayOneShot(buttonShow);
        switch (button)
        {
            case XboxButton.A:
                buttonA.enabled = true;
                activeButton = buttonA;
                break;
            case XboxButton.B:
                buttonB.enabled = true;
                activeButton = buttonB;
                break;
            case XboxButton.X:
                buttonX.enabled = true;
                activeButton = buttonX;
                break;
            case XboxButton.Y:
                buttonY.enabled = true;
                activeButton = buttonY;
                break;
            case XboxButton.LeftStick:
                leftStick.SetActive(true);
                break;
            default:
                buttonLBRB.SetActive(true);
                break;
        }
    }

    public void ShowButton(XboxButton button, Vector3 position)
    {
        worldPosition = position;
        ShowButton(button);
    }

    public void HideButton()
    {
        buttonA.enabled = false;
        buttonB.enabled = false;
        buttonX.enabled = false;
        buttonY.enabled = false;
        buttonLBRB.SetActive(false);
        leftStick.SetActive(false);
        worldPosition = Vector3.zero;
    }

    public void ShowAplusX()
    {
        audioSource.PlayOneShot(buttonShow);
        aPlusX.gameObject.SetActive(true);
    }
    public void HideAplusX()
    {
        aPlusX.gameObject.SetActive(false);
    }
}
