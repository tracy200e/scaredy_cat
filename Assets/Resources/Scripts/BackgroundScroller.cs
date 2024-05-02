using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public static float speed = .1f;
    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        // get the background renderer
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // set the offset using Time.time, which is the time since the game began
        float offset = Time.time * speed;

        // scrolling effect on one axis
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        renderer.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
    }
}
