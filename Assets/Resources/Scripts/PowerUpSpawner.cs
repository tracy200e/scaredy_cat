using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowerups());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerups()
    {
        while (true) {

            // number of gems we could spawn vertically
            int powerUpsThisRow = Random.Range(1, 3);

            // instantiate a random powerups past the right the right edge of the screen
            for (int i = 0; i < powerUpsThisRow; i++)
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(20, Random.Range(5, -2), -5), 
                    Quaternion.Euler(0f, -90f, 0f));
            }
            
            // pause 7-10 seconds until the next monster spawns
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }
}
