using UnityEngine;

public class AdviceScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject advice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Obstacles") {
            advice.SetActive(true);
        }
        if (col.gameObject.tag == "Enemy") {
            advice.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Obstacles") {
            advice.SetActive(false);
        }
        if (col.gameObject.tag == "Enemy") {
            advice.SetActive(false);
        }
    }
}
