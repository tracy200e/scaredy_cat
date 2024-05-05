using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBed : MonoBehaviour
{
    public static float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        } else
        {
            transform.Translate(-PathGenerator.speedFactor * speed * Time.deltaTime, 0, 0);
        }
    }
}
