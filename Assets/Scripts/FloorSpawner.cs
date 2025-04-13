using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour
{
    public GameObject Floor;
    
    void Start()
    {
        StartCoroutine(SpawnFloor());
    }
    
    private IEnumerator SpawnFloor() {
        while (true)
        {
            int spawnTime = Random.Range(10,20);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(Floor, new Vector2(transform.position.x, transform.position.y-0.6f), transform.rotation);
        }
    }
}
