using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float jumpSpeed = 7f;
    private float walkSpeed = 5f;
    private bool InGround = true;
    public SpriteRenderer sr;
    Vector3 playerVelocity;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);

        if (Input.GetKey("space") && (InGround == true)){
            rb2d.linearVelocity = new Vector2(walkSpeed, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Wall") {
            if (walkSpeed == 5f) {
                walkSpeed = -5f;
                sr.flipX = true;
            }
            else if (walkSpeed == -5f) {
                walkSpeed = 5f;
                sr.flipX = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.tag == "Ground") {
            InGround = true;
            rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y-1f);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Ground") {
            InGround = false;
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "Ground") {
            InGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Ground") {
            InGround = false;
        }
    }
}
