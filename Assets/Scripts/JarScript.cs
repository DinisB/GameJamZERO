using System;
using UnityEngine;

public class JarScript : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb2d;
    private float jumpSpeed = 5f;
    private float walkSpeed = -3f;

    void Update()
    {
        rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpSpeed);
        }
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("DeathWall")) {
            Destroy(gameObject);
        }
    }
}
