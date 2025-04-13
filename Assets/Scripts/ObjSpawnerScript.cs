using UnityEngine;
using System.Collections;

public class ObjSpawnerScript : MonoBehaviour
{
    
    [SerializeField] private GameObject Skelly;
    [SerializeField] private GameObject[] Objs;
    
    private void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnSkelly());
    }

    
    private IEnumerator SpawnObstacle() {
        while (true)
        {
            int toSpawn = Random.Range(0,4);
            Instantiate(Objs[toSpawn], new Vector2(transform.position.x, transform.position.y) + GetOffSet(toSpawn), transform.rotation);
            yield return new WaitForSeconds(Random.Range(4,6));
        }
    }

    private Vector2 GetOffSet(int spawn)
    {
        Vector2 result = spawn switch
        {
            0 => new Vector2(0, -0.6f),
            1 => Vector2.zero,
            2 => new Vector2(0f, -0.8f),
            3 => new Vector2(0F, -0.9f),
            _ => Vector2.zero
        };
        return result;
    }

    private IEnumerator SpawnSkelly() {
        while (true)
        {
            Instantiate(Skelly, new Vector2(transform.position.x, transform.position.y+1), transform.rotation);
            yield return new WaitForSeconds(Random.Range(10,15));
        }
    }
}
