using UnityEngine;

public class GrassScript : MonoBehaviour
{
    
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
    }
    
}
