using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables for Player's body movement
    Rigidbody playerBody;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpSpeed = 10.0f;
    public float jumptHeight = 10.0f;
    private float gravityValue = 9.81f;


    public int powerUpTotal = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        // get the Player's velocity
        Vector3 velocity = playerBody.velocity;

        // when the "Jump" key or space bar is pressed
        if (Input.GetButtonDown("Jump"))
        {
            // The Player jumps at a designated height
            velocity.y += Mathf.Sqrt(jumptHeight * 2 * gravityValue);
        }

        // reassign the velocity value to the Player's rigidbody
        playerBody.velocity = velocity;

        // when the player falls
        if (playerBody.velocity.y < 0)
        {
            // accelerate the fall in this particular frame
            playerBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        
        // if we're jumping upward and not pressing the "Jump" button
        } else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // accelerate the fall at a slower speed in this particular frame
            playerBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // if (powerUpTotal > 2)
        // {
        //     transform.Translate(Vector3.forward * Time.deltaTime);
        // }
    }

    public void ConsumePowerUp() {
        powerUpTotal += 1;

        GetComponent<AudioSource>().Play();
        GetComponent<ParticleSystem>().Play();
    }
}
