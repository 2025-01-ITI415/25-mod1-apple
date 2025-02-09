using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{

    public void OnBackButton(){
        SceneManager.LoadScene(0);
    }

    /*private Transform entryContainer;
    private Transform entryTemplate;
    private void Awake(){  
        entryContainer = transform.Find("highScoreEntryContainer");
        entryTemplate = transform.Find("highScoreEntryTemplate")

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        for (int i=0; i<10; i++){
            Transform entryTranform = Instantiate(entryTemplate, entryContainer);
            rectTransform entryRectTransform = entryTranform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight + i);
            entryTranform.gameObject.SetActive(true);

            int rank = i+1;
            string rankString;
            switch (rank){
                default:
                    rankString = rank + "th"; break;

                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3: rankString = "3rd"; break;

            }

            entryTranform.Find("posText").GetComponent<Text>().text = rankString;

            int score = Random.Range(0,10000);

            string name = "AAA"

            entryTranform.Find("nameText").GetComponent<Text>().text = name;
            entryTranform.Find("scoreText").GetComponent<Text>().text = score.ToString();

          

        } 
    }*/
}
