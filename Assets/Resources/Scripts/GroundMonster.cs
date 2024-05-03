using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonster : MonoBehaviour
{
    public Animator animator;
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
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bridge"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            animator.SetTrigger("Hit");
            Destroy(gameObject);
        }
    }
}
