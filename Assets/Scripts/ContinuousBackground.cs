using UnityEngine;

public class ContinuousBackground : MonoBehaviour
{
    private float lenght;
    private float startPos;

    private Transform cam;

    [SerializeField] private float ParallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }


    void Update()
    {
        float rePos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3(startPos + Distance, transform.position.y, transform.position.z);

        if (rePos > startPos + lenght)
        {
            startPos += lenght;
        }
        else if(rePos < startPos - lenght) // Essa parte é "inutil" pois o background n vai se mover para atrás, mas é melhor garantir
        {
            startPos -= lenght;
        }
    }
}
