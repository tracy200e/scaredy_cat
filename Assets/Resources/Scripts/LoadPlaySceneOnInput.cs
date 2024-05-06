using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlaySceneOnInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // if the Player presses the 'Enter' key
        if (Input.GetAxis("Submit") == 1)
        {
            // take the Player to the Play Scene
            SceneManager.LoadScene("Play");
        }
    }
}
