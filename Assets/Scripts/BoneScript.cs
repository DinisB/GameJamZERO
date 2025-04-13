using UnityEngine;

public class BoneScript : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _jumpSpeed = 5f;
    private float _walkSpeed = -3f;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb2d.linearVelocity = new Vector2(_walkSpeed, _rb2d.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            _rb2d.linearVelocity = new Vector2(_rb2d.linearVelocity.x, _jumpSpeed);
            // Why use jumpSpeed at all if this is not affecting anything? Is this supposed to be applied on the RigidBody Velocity?
            _jumpSpeed = _jumpSpeed - _jumpSpeed/8;
        }
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("DeathWall")) {
            Destroy(gameObject);
        }
    }
}
