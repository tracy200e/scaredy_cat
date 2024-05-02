using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
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
        Destroy(gameObject);
    }
}
