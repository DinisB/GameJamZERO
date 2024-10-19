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
        rb2d.linearVelocity = new Vector2(-5, rb2d.linearVelocity.y);
    }

}
