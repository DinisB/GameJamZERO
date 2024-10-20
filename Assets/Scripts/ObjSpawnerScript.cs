using UnityEngine;
using System.Collections;

public class ObjSpawnerScript : MonoBehaviour
{
    public GameObject Skelly;
    public GameObject[] Objs;
    public int ObjToSpawn;
    void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnSkelly());
    }

    void Update()
    {
        
    }
    IEnumerator SpawnObstacle() {
        ObjToSpawn = Random.Range(0,4);
        if (ObjToSpawn == 0) {
            Instantiate(Objs[0], new Vector2(transform.position.x, transform.position.y-0.6f), transform.rotation);
        }
        if (ObjToSpawn == 1) {
            Instantiate(Objs[1], new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }
        if (ObjToSpawn == 2) {
            Instantiate(Objs[2], new Vector2(transform.position.x, transform.position.y-0.8f), transform.rotation);
        }
        if (ObjToSpawn == 3) {
            Instantiate(Objs[3], new Vector2(transform.position.x, transform.position.y-0.9f), transform.rotation);
        }
        yield return new WaitForSeconds(Random.Range(4,6));
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnSkelly() {
        Instantiate(Skelly, new Vector2(transform.position.x, transform.position.y+1), transform.rotation);
        yield return new WaitForSeconds(Random.Range(10,15));
        StartCoroutine(SpawnSkelly());
    }
}
