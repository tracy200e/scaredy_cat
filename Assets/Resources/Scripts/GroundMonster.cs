using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonster : MonoBehaviour
{
    public Animator animator;
    public static float speed = 1.0f;
    private static float LEVEL_BELOW_GROUND = -9.5f;

    // Update is called once per frame
    void Update()
    {
        // if the Ground Monster passes beyond the screen horizontally
        if (transform.position.x < -25)
        {
            // make it disappear
            Destroy(gameObject);
        }
        // if the Ground Monster falls below the ground
        else if (transform.position.y < LEVEL_BELOW_GROUND)
        {
            // make it disappear
            Destroy(gameObject);
        } 
        else
        {
            // the Ground Monster moves with the ground, which makes it look still
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if the monster collides with the bridge
        if (other.CompareTag("Bridge"))
        {
            // kill the monster
            Destroy(gameObject);
        }

        // if the monster collides with the Player
        if (other.CompareTag("Player"))
        {
            // animate the monster for a hit-and-die effect
            // reference: https://docs.unity3d.com/ScriptReference/Animator.SetTrigger.html
            animator.SetTrigger("Hit");

            // destroy the monster
            StartCoroutine(Die());

            // penalise the Player 
            PlayerController.powerUpTotal -= 1;
            
        }
    }

    IEnumerator Die()
    {
        // wait for the animation to complete
        yield return new WaitForSeconds(3);

        // make the monster disappear
        Destroy(gameObject);
    }
}
