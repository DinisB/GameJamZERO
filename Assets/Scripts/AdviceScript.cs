using UnityEngine;

public class AdviceScript : MonoBehaviour
{
    
    public GameObject advice;
    
    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.CompareTag("Obstacles") || col.gameObject.CompareTag("Enemy")) advice.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Obstacles") || col.gameObject.CompareTag("Enemy")) advice.SetActive(false);
    }
    
}
