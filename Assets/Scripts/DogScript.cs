using UnityEngine;
using System.Collections;
using TMPro;

public class DogScript : MonoBehaviour
{
    public int HighScore = 0;
    public int HighMeters = 0;
    private Rigidbody2D rb2d;
    private float jumpSpeed = 20f;
    private float walkSpeed = 4f;
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
    public GameObject[] Spawners;
    public GameObject parede;
    public GameObject UIDog;
    public TMP_Text highscoretext;
    public TMP_Text highmeterstext;

    IEnumerator MetersAdd() {
        Meters++;
        meterstext.SetText("Meters: " + Meters.ToString());
        yield return new WaitForSeconds(0.1f);
        if (DogAlive == true) {
            StartCoroutine(MetersAdd());
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        HighScore = PlayerPrefs.GetInt("High Score", 0);
        HighMeters = PlayerPrefs.GetInt("High Meters", 0);
        StartCoroutine(MetersAdd());
    }
    IEnumerator BarkTimer() {
        Barking = true;
        barksound.Play();
        yield return new WaitForSeconds(1);
        barkspr.SetActive(false);
        yield return new WaitForSeconds(1);
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
            if (Score > HighScore){
                PlayerPrefs.SetInt("High Score", Score);
            }

            if (Meters > HighMeters){
                PlayerPrefs.SetInt("High Meters", Meters);
            }

            highscoretext.SetText("HighScore:" + PlayerPrefs.GetInt("High Score"));
            highmeterstext.SetText("Most Meters:" + PlayerPrefs.GetInt("High Meters"));
            rb2d.linearVelocity = new Vector2(-5f, rb2d.linearVelocity.y);
            gameObject.GetComponent<Animator>().SetBool("Dead", true);
            parede.SetActive(false);
            UIDog.SetActive(true);
        }
        if (DogAlive== true) {
            rb2d.linearVelocity = new Vector2(0, rb2d.linearVelocity.y-1);
        }


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
            gameObject.GetComponent<AudioSource>().Play();
            scoretext.SetText("Score: " + Score.ToString());
        }

        if (col.gameObject.tag == "Obstacles") {
            DogAlive = false;
            Spawners[0].SetActive(false);
            Spawners[1].SetActive(false);
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

    public void BarkButton() {
        if (DogAlive == true){
            Bark();
        }
    }

    public void JumpButton() {
        if ((InGround == true) && (DogAlive == true)){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpSpeed);
        }
    }

    public void LeftButton() {
        if (DogAlive == true){
            rb2d.linearVelocity = new Vector2(-walkSpeed, rb2d.linearVelocity.y);
        }
    }

    public void RightButton() {
        if (DogAlive == true){
            rb2d.linearVelocity = new Vector2(walkSpeed, rb2d.linearVelocity.y);
        }
    }
}
