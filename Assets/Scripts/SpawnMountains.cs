using UnityEngine;
using System.Collections;

public class SpawnMountains : MonoBehaviour
{
    public GameObject[] pref;
    private int escolha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnMountainTime());
        Instantiate(pref[escolha], new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMountainTime(){
        yield return new WaitForSeconds(1.2f);
        escolha = escolha + 1;
        if (escolha == 3) {
            escolha = 0;
        }
        Instantiate(pref[escolha], new Vector2(transform.position.x, transform.position.y), transform.rotation);
        StartCoroutine(SpawnMountainTime());
    }
}
