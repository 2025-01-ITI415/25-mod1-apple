using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI     Text;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to the ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get the Text component of that GameObject
        Text = scoreGO.GetComponent<TextMeshProUGUI>();

        // Set the starting number of points to zero
        Text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {       
        // added line of script calling the unityengine.scenemanagement
        // which notices once the game swaps to _scene_0 to then have the 
        // baskets move along with the cursor. this avoids the basket moving
        // on the title screen!
       if ( SceneManager.GetActiveScene().name == "_Scene_0" ){
        // Get the current screen psotion of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
        
        // Move the z position of this basket to the z position of the Mouse
        Vector3 pos = this.transform.position;
         pos.z = mousePos3D.z;
         this.transform.position = pos; }
         }

    void OnCollisionEnter ( Collision coll ) {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if ( collidedWith.tag == "Apple" || collidedWith.tag == "Golden" || collidedWith.tag == "Poison" ) {
            Destroy( collidedWith );

            // parse the text of scoreGT into an int
            int score = int.Parse( Text.text );

            // Add points for catching the apple
            if ( collidedWith.tag == "Apple" ){
              score += 100;
            } else if ( collidedWith.tag == "Golden" ){
                score += 300;
            } else if ( collidedWith.tag == "Poison" ){
                score -= 100;
            }


            // Convert the score back to a string and display it
            Text.text = score.ToString();

            // Track the high score
            if (score > HighScore.score){
                HighScore.score = score;
            }
        }
    }
}
