using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartDog : MonoBehaviour
{
    private bool RestartDogVar = false;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)){
            StartCoroutine(DogRestart());
        }
        if (RestartDogVar == true) {
            transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
        }
    }

    IEnumerator DogRestart() {
        gameObject.GetComponent<Animator>().SetBool("Restart", true);
        RestartDogVar = true;
        yield return new WaitForSeconds(3f);
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync("Loading");
    }
}
