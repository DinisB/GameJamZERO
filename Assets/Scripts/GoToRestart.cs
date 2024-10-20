using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToRestart : MonoBehaviour
{
    public string scene;
    public void LoadingLevelScript() 
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(scene);
    }


}
