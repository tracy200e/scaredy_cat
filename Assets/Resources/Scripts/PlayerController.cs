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
    private bool hasTurnedAround = false;

    // enemy's position
    public static float ENEMY_POSITION = 12f;
    public LayerMask layersToHit = 1<<4;

    // game score
    public static int powerUpTotal;

    // screen boundaries
    private static float LEVEL_CEILING = 9f;
    private static float LEVEL_BELOW_GROUND = -9.5f;
    private static float LEVEL_LEFT_EDGE = -12.5f;
    private static float LEVEL_RIGHT_EDGE = 15.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        powerUpTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        // if the Player falls behind
        if (transform.position.x < LEVEL_LEFT_EDGE)
        {
            // the Player loses the game
            LoseGame();
        }

        // if the Player goes over the right edge of the screen
        if (transform.position.x > LEVEL_RIGHT_EDGE)
        {
            // the Player does not go over
            transform.position = new Vector3(LEVEL_RIGHT_EDGE, transform.position.y, transform.position.z);
        }

        // if the Player falls below ground
        if (transform.position.y < LEVEL_BELOW_GROUND)
        {
            // the Player loses the game
            LoseGame();
        }

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
        
        // the Player's jump speed is dampened when they hit the top of the screen
        if (transform.position.y > LEVEL_CEILING && velocity.y > 0)
        {
            velocity.y *= 0.2f;
            transform.position = new Vector3(transform.position.x, 6, -5);
        }
        // if the Player passes the Target
        if (transform.position.x > ENEMY_POSITION + 2 && velocity.x > -1.0f)
        {
            // make the Player fall behind a little
            velocity = velocity - Vector3.right * 0.4f;
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
    }

    public void ConsumePowerUp() {

        // increase score
        powerUpTotal += 1;

        // increase the Player's speed
        playerBody.velocity += Vector3.right * 1.5f;

        // play sound and particle effect
        GetComponent<AudioSource>().Play();
        GetComponent<ParticleSystem>().Play();
    }

    public void LoseGame() {

        // switch to the Game Over Scene
        SceneManager.LoadScene("GameOver");

        // restore the score count
        powerUpTotal = 0;
    }
}
