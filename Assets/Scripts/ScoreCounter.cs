using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TextMeshPro uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString( "#,0" );
    }
}
