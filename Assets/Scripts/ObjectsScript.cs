using UnityEngine;
using System.Collections;

public class ObjectsScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    void Start()
    {

    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(-10, rb2d.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "DeathWall") {
            Destroy(gameObject);
        }
    }

}
