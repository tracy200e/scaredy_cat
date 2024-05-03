using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables for Player's body movement
    Rigidbody playerBody;
    Vector3 velocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpSpeed = 10.0f;
    public float jumptHeight = 10.0f;
    public float runSpeed = 10.0f;
    private float gravityValue = 9.81f;
    private float horizontal;

    // game score
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
        velocity = playerBody.velocity;

        /// Reference: https://youtu.be/7KiK0Aqtmzc?si=02e46dB4F17G6vmZ
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
        } else
        {
            velocity.y = 0;
        }

        if (powerUpTotal > 10)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    public void ConsumePowerUp() {
        powerUpTotal += 1;

        GetComponent<AudioSource>().Play();
        GetComponent<ParticleSystem>().Play();
    }

    // private void OnCollisionEnter(Collision collider)
    // {
    //     var speed = velocity.magnitude;
    //     var direction = Vector3.Reflect(velocity.normalized, collider.contacts[0].normal);

    //     playerBody.velocity = direction * Mathf.Max(speed, 0f);
    // }
}
