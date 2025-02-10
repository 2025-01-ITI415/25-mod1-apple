using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the next scene (change "_Scene_0" to the actual name of the scene you want to load)
        SceneManager.LoadScene("_Scene_0");
    }
}
