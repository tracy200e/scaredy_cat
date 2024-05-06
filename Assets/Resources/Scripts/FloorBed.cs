using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBed : MonoBehaviour
{
    public static float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // if the Floor Bed object passes the designated point
        if (transform.position.x < -50)
        {
            // make the Floor Bed object disappear
            Destroy(gameObject);
        } else
        {
            // move the Floor Bed object with the designated speed
            transform.Translate(-PathGenerator.speedFactor * speed * Time.deltaTime, 0, 0);
        }
    }
}
