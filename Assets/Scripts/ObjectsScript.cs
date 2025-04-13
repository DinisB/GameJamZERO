using UnityEngine;
using System.Collections;

public class ObjectsScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(-10, rb2d.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("DeathWall")) {
            Destroy(gameObject);
        }
    }

}
