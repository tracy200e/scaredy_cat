using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        } else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }

        transform.Rotate(0, 2f, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            
            if (playerController != null)
            {
                playerController.ConsumePowerUp();
            }
            Destroy(gameObject);
        } 
        else
        {
            Debug.LogError("PlayerController component cannot be found on the collided object.");
        }        
    }
}
