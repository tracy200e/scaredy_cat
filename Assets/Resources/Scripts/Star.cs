using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // if the Star passes beyond the screen horizontally
        if (transform.position.x < -25)
        {
            // make it disappear
            Destroy(gameObject);
        } else
        {
            // move the Star(s) as fast as the path
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }

        // constantly rotate the Star
        transform.Rotate(0, 2f, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // if the collided object is Player
        if (other.CompareTag("Player"))
        {
            // grab the Player's component on collision
            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            
            // check if the Player is there
            if (playerController != null)
            {
                // let the Player consume Star
                playerController.ConsumePowerUp();
            }

            // make the Star disappear
            Destroy(gameObject);
        } 
        else
        {
            // log error to the console
            Debug.LogError("PlayerController component cannot be found on the collided object.");
        }        
    }
}
