using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Player player;
    public GameObject[] tutorials;
    public Image blackscreen;
    public Transform spawn;

    public AudioClip fadeStart;
    public AudioClip fadeEnd;


    public AudioSource audioSource;

    public int startIndex;

    int index;

    public CustomPassVolume volume;

    public SkinnedMeshRenderer sonicMesh;

    private Color targetColor;

    float fade;

    float fadeTarget;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        fadeTarget = 1;

        if(startIndex < tutorials.Length)
        {
            index = startIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        blackscreen.color = Color.Lerp(blackscreen.color, targetColor, 5 * Time.deltaTime);

        fade = Mathf.Lerp(fade, fadeTarget, 3 * Time.deltaTime);

        Shader.SetGlobalFloat("_GlobalFade", fade);

        foreach (Material material in sonicMesh.sharedMaterials)
        {
            
        }


        if(fade < 0.95f)
        {
            volume.enabled = true;
        }
        else
        {
            volume.enabled = false;
        }

        if (fade < 0.03f)
        {
            player.transform.position = spawn.position;
            player.transform.rotation = spawn.rotation;
            player.stateMachine.Play();
            audioSource.PlayOneShot(fadeEnd);
            targetColor = Color.clear;
            sonicMesh.shadowCastingMode = ShadowCastingMode.On;
            fadeTarget = 1;
            player.isUnderwater = false;
            Time.timeScale = 1;
            player.stateMachine.ChangeState(player.StateIdle);

            if (index < tutorials.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            for (int i = 0; i < tutorials.Length; i++)
            {
                if (i == index)
                {
                    tutorials[i].SetActive(true);
                }
                else
                {
                    tutorials[i].SetActive(false);

                    
                }
            }

      
            try
            {
                GameObject go = tutorials[index].transform.Find("RingChain").gameObject;

                if (go != null)
                {
                    var newGo = Instantiate(go);

                    newGo.SetActive(true);

                    newGo.name = "Instance";
                }
            }
            catch
            {

            }           
        }
       

        if (Input.GetButtonDown(XboxButton.Back))
        {
            ChangeTutorial();

            audioSource.PlayOneShot(fadeStart);
        }
    }


    public void ChangeTutorial()
    {
        player.stateMachine.Pause();

        targetColor = Color.black;
        sonicMesh.shadowCastingMode = ShadowCastingMode.Off;
        fadeTarget = 0;
        GameplayUI.instance.HideButton();
       
    }
}
