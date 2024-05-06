using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://cs50.harvard.edu/extension/games/2024/spring/#helicopter-game-3d
public class BackgroundScroller : MonoBehaviour
{
    public static float speed = 0.05f;
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
    }
}
