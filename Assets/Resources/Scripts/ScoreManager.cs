using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        // update the text input
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the score text based on the Player's score per level
        score.text = PlayerController.powerUpTotal.ToString();
    }
}
