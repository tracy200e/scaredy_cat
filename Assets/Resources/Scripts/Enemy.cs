using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Ray ray;
    public LayerMask layersToHit = 1<<4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Play");
            LevelManager.gameLevel++;
            PlayerController.powerUpTotal = 0;
            PathGenerator.speedFactor++;
        }
    }

    void detectWater()
    {
        RaycastHit hit;
        ray = new Ray(gameObject.transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layersToHit))
        {
            Debug.Log("Cat hit something at " + hit.distance + "distance");
        }
    }
}
