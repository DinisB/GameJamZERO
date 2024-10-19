using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScript : MonoBehaviour
{
    private IEnumerator LoadingLevel() {
        yield return new WaitForSeconds(2);
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync("Game");
    }
    void Start()
    {
        StartCoroutine(LoadingLevel());
    }

}
