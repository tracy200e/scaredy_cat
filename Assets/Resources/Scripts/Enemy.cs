using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // move to the next level
            LevelManager.gameLevel++;
            SceneManager.LoadScene("Play");

            // speed up the game
            PathGenerator.speedFactor++;

            // restart score count
            PlayerController.powerUpTotal = 0;
        }
    }
}
