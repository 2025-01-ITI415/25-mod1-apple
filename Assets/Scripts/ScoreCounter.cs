using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0; // The score variable
    public TextMeshProUGUI uiText;  // TextMeshProUGUI reference

    // Start is called before the first frame update
    void Start()
    {
        // If the Text component is not assigned in the Inspector, try to find it automatically
        if (uiText == null)
        {
            uiText = GetComponent<TextMeshProUGUI>();

            if (uiText == null)
            {
                Debug.LogError("TextMeshProUGUI component not assigned or found! Assign it in the Inspector.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the text only if the Text component is assigned
        if (uiText != null)
        {
            uiText.text = score.ToString("#,0");
        }
    }
}



