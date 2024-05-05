using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // variables for Player's body movement
    Rigidbody playerBody;
    public Vector3 velocity;
    public float fallMultiplier = 2.0f;
    public float lowJumpMultiplier = 1.5f;
    public float jumptHeight = 2.0f;
    public float runSpeed = 10.0f;
    private float gravityValue = 9.81f;
    private float horizontal;

    // game score
    public static int powerUpTotal;

    private static float LEVEL_CEILING = 6;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        powerUpTotal = 0;
        // animator = GetComponent<Animator>();
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
            // animator.SetBool("Jump", true);
            // the Player jumps at a designated height
            velocity.y += Mathf.Sqrt(jumptHeight * 2 * gravityValue);
        }
        
        if (transform.position.y > LEVEL_CEILING && velocity.y > 0)
        {
            velocity.y *= 0.2f;
            transform.position = new Vector3(transform.position.x, 6, -5);
        }

        // reassign the velocity value to the Player's rigidbody
        playerBody.velocity = velocity;

        // when the Player falls
        if (playerBody.velocity.y < 0)
        {
            // accelerate the fall in this particular frame
            playerBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        
        // if we're moving upward and not pressing the "Jump" button
        } 
        else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // accelerate the fall at a slower speed in this particular frame
            playerBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        } 
        else
        {
            velocity.y = 0;
        }

        if (transform.position.y < -8)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ConsumePowerUp() {
        powerUpTotal += 1;
        playerBody.velocity += Vector3.right * 2;
        GetComponent<AudioSource>().Play();
        GetComponent<ParticleSystem>().Play();
    }
}
