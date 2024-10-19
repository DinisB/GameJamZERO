using UnityEngine;
using System.Collections;
using TMPro;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float jumpSpeed = 20f;
    private float walkSpeed = 5f;
    private bool InGround = true;
    Vector3 playerVelocity;
    public GameObject barkspr;
    private bool Barking = false;
    public AudioSource barksound;
    public int Score = 0;
    public int Meters = 0;
    public TMP_Text scoretext;
    public TMP_Text meterstext;
    private bool DogAlive = true;

    IEnumerator MetersAdd() {
        Meters = Meters + 1;
        meterstext.SetText("Meters: " + Meters.ToString());
        yield return new WaitForSeconds(0.1f);
        if (DogAlive == true) {
            StartCoroutine(MetersAdd());
        }
    }
    void Start()
    {
        StartCoroutine(MetersAdd());
    }
    IEnumerator BarkTimer() {
        Barking = true;
        barksound.Play();
        yield return new WaitForSeconds(1);
        barkspr.SetActive(false);
        yield return new WaitForSeconds(2);
        Barking = false;
    }

    void Bark() {
        if (Barking == false) {
            barkspr.SetActive(true);
            StartCoroutine(BarkTimer());
        }
    }
    void FixedUpdate()
    {
        if (DogAlive == false) {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x-3, rb2d.linearVelocity.y);
        }
        rb2d.linearVelocity = new Vector2(0, rb2d.linearVelocity.y-1);

        if (Input.GetKey("z") && (InGround == true) && (DogAlive == true)){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && (DogAlive == true)){
            rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (DogAlive == true)){
            rb2d.linearVelocity = new Vector2(-walkSpeed, rb2d.linearVelocity.y);
        }

        if (Input.GetKey("x") && (DogAlive == true)){
            Bark();
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Ground") {
            InGround = true;
            rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
        }
    }



    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bones" && DogAlive == true) {
            Score = Score + 1;
            scoretext.SetText("Score: " + Score.ToString());
        }

        if (col.gameObject.tag == "Obstacles") {
            DogAlive = false;
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
