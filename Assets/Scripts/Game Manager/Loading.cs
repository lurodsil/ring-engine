using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [HideInInspector] public string sceneName;

    private void OnEnable()
    {
        GameManager.instance.OnLoadingStart();
    }

    private void OnDisable()
    {
        GameManager.instance.OnLoadingEnd();
    }

    private void Start()
    {
        sceneName = GameManager.instance.sceneLoading;

        Destroy(GameManager.instance.gameObject);

        StartCoroutine(LoadNewScene());
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