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
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(-23, -8, -5), 
                    Quaternion.identity);
        StartCoroutine(GeneratePath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GeneratePath()
    {
        while (true)
        {

            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(19, -8, -5), 
                    Quaternion.identity);

            yield return new WaitForSeconds(42f / speedFactor);
        }
    }
}
