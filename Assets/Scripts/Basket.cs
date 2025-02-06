using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        // Find the ScoreCounter object and get its ScoreCounter component
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }
        else
        {
            Debug.LogError("ScoreCounter object not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the basket based on mouse position
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Log the tag of the collided object
        GameObject collidedWith = coll.gameObject;
        Debug.Log("Collided with object with tag: " + collidedWith.tag);

        // Check if the collided object has the "Apple" tag
        if (collidedWith.CompareTag("Apple"))
        {
            Debug.Log("Regular apple hit - adding 100 points");
            Destroy(collidedWith);

            // Update the score if scoreCounter is not null
            if (scoreCounter != null)
            {
                scoreCounter.score += 100;
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            }
            else
            {
                Debug.LogError("ScoreCounter is null. Cannot update score.");
            }
        }
        // Check if the collided object has the "Gold Apple" tag
        else if (collidedWith.CompareTag("Gold Apple"))
        {
            Debug.Log("Gold apple hit - adding 200 points");
            Destroy(collidedWith);

            // Update the score if scoreCounter is not null
            if (scoreCounter != null)
            {
                scoreCounter.score += 200;
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            }
            else
            {
                Debug.LogError("ScoreCounter is null. Cannot update score.");
            }
        }
        else
        {
            Debug.LogWarning("Collided with an object that is not an Apple or Gold Apple. Tag: " + collidedWith.tag);
        }
    }
}