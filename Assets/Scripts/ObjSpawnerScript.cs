using UnityEngine;
using System.Collections;

public class ObjSpawnerScript : MonoBehaviour
{
    public GameObject Skelly;
    public GameObject Lapida;
    public GameObject Jarra;
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
        ObjToSpawn = Random.Range(0,2);
        if (ObjToSpawn == 0) {
            Instantiate(Lapida, new Vector2(transform.position.x, transform.position.y-0.6f), transform.rotation);
        }
        if (ObjToSpawn == 1) {
            Instantiate(Jarra, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }
        yield return new WaitForSeconds(6);
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnSkelly() {
        Instantiate(Skelly, new Vector2(transform.position.x, transform.position.y+1), transform.rotation);
        yield return new WaitForSeconds(12);
        StartCoroutine(SpawnSkelly());
    }
}
