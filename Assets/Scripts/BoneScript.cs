using UnityEngine;

public class BoneScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float jumpSpeed = 5f;
    private float walkSpeed = -3f;
    void Start()
    {
        
    }

    void Update()
    {
        rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Ground") {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpSpeed);
            jumpSpeed = jumpSpeed-jumpSpeed/8;
        }
        if (col.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "DeathWall") {
            Destroy(gameObject);
        }
    }
}
