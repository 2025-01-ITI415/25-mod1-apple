using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartButton() {
        SceneManager.LoadScene( "_Scene_0" );
    }

    public void PlayAgainButton() {
        SceneManager.LoadScene( "_Scene_0" );
    }

    public void GoToTitleScreenButton() {
        SceneManager.LoadScene( "Start" );
    }
}
