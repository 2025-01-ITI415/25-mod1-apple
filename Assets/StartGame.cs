using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartGame : MonoBehaviour
{
    // This function is called when the Start button is clicked 
    public void OnStartButtonClicked()
    {
        // Load the main game Scene 
        SceneManager.LoadScene("MainGameScene"); // Replace "MainGameScene"
    }
}
