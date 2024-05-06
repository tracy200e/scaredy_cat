using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelManager : MonoBehaviour
{
    public Text level;
    public static int gameLevel = 1;

    void Awake()
    {
        // grab the text component
        level = GetComponent<Text>();

        // update the text input
        level.text = "Level " + gameLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
