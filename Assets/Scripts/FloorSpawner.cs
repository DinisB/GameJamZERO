using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour
{
    public GameObject Floor;
    public int SpawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFloor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFloor() {
        SpawnTime = Random.Range(10,20);
        yield return new WaitForSeconds(SpawnTime);
        Instantiate(Floor, new Vector2(transform.position.x, transform.position.y-0.6f), transform.rotation);
        StartCoroutine(SpawnFloor());
    }
}
