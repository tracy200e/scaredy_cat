using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    public static int speedFactor = 1;

    // Start is called before the first frame update
    void Start()
    {   
        // generate the first path
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(-23, -8, -5), 
                    Quaternion.identity);

        // start generating the following paths
        StartCoroutine(GeneratePath());
    }

    IEnumerator GeneratePath()
    {
        while (true)
        {
            // create the path at the specific x position
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(19, -8, -5), 
                    Quaternion.identity);

            // wait to generate the next path
            yield return new WaitForSeconds(42f / speedFactor);
        }
    }
}
