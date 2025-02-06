using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
    public ScoreCounter scoreCoutner;
{
    // Start is called before the first frame update
    void Start(){
       GameObject scoreGO = GameObject.Find( "ScoreCounter" );
       scoreCounter = scoreGO.GetComponent<ScoreCounter>(); 
    }

    // Update is called once per frame
    void Update(){
        // get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;      
         
        // The Camera’s z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, select the Main Camera
        //  in the Hierarchy and set its tag to MainCamera in the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;  

        // convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

        //  Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll) {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
            scoreCounter.score += 100;
        }
    }
}
