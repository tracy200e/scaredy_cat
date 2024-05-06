using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters()
    {
        while (true) {

            // instantiate a random monster past the right the right edge of the screen
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(0, -3, -5), 
                Quaternion.Euler(0f, -90f, 0f));

            // pause 7-10 seconds until the next monster spawns
            yield return new WaitForSeconds(Random.Range(7,10));
        }
    }
}
