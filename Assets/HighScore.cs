using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    private TextMeshProUGUI scoreText;
    private void Awake()
    {
        //if the playerprefs highscore already exists,read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //assign the high score to highscore
        PlayerPrefs.SetInt("HighScore", score);

    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScoreText();
        }
    }
    void UpdateHighScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "HighScore: " + score;
        }
    }
}
