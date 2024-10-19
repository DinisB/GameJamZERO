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
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, rb2d.linearVelocity.y);

        if (Input.GetKey("space") && (InGround == true)){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            rb2d.linearVelocity = new Vector2(-walkSpeed, rb2d.linearVelocity.y);
        }
    }


    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Ground") {
            InGround = true;
            rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
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
