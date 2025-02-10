using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this line enables use of uGUI. // a 

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT; //a 
    void Start()
    {
        //find a refrence
        GameObject scoreGO = GameObject.Find("ScoreCounter"); //b
                                                              //get the text componet of that GameObject 
        scoreGT = scoreGO.GetComponent<Text>();
        // set the starting number of points to 0 
        scoreGT.text = "0";
    }
    void Update()
    {
        // get the current screen position of the mouse input
        Vector3 mousePos2D = Input.mousePosition; //a
                                                  //the camera's z position set how far to push the mouse into 3d
        mousePos2D.z = -Camera.main.transform.position.z; //b
                                                          //convert the point from 2d screen space into 3d game world in space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //c
                                                                         //move the x posiion of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }


    void OnCollisionEnter (Collision coll)
    {
        //find out what hit the basket 
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "apple")
        {
            Destroy(collidedWith);

            //parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text); //d
                                                 //add points for catching the apple
            score += 100;
            //convert the score back to a string and display it 
            scoreGT.text = score.ToString();
            //track the high score 
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}