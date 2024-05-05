using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelManager : MonoBehaviour
{
    public Text level;

    void Awake()
    {
        level = GetComponent<Text>();

        level.text = "Level " + Enemy.gameLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
