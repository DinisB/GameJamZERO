using UnityEngine;
using System.Collections;

public class SpawnGrass : MonoBehaviour
{
    public GameObject pref;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnGrassTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnGrassTime(){
        yield return new WaitForSeconds(.75f);
        Instantiate(pref, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        StartCoroutine(SpawnGrassTime());
    }
}
