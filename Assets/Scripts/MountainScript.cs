using UnityEngine;

public class MountainScript : MonoBehaviour
{
    
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - .1f, transform.position.y);
    }
    
}
