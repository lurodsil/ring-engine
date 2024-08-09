using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [HideInInspector] public string sceneName;


    private void Start()
    {
        GameManager.instance.OnLoadingStart();

        sceneName = GameManager.instance.sceneLoading;

        StartCoroutine(LoadNewScene());
    }
    private void Update()
    {
        GameManager.instance.ScreenFadeIn();
        GameManager.instance.AudioFadeIn();
    }

    IEnumerator LoadNewScene()
    {      
        yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        GameManager.instance.gameState = GameState.Playing;

        while (!async.isDone)
        {
            yield return null;
        }
    }
}