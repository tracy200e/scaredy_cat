using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private TMP_Text level;

    void Awake()
    {
        level = GetComponent<TMP_Text>();

        level.text = "Level " + Enemy.gameLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
