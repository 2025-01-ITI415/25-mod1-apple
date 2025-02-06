using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject goldApplePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float goldDropChance = 0.2f;

    void Start () {
        Invoke( "DropApple", 2f );
    }

    void DropApple()
    {
        GameObject prefabToUse;
        if (Random.value < goldDropChance)
        {
            if (goldApplePrefab == null)
            {
                return;
            }
            prefabToUse = goldApplePrefab;
        }
        else
        {
            if (applePrefab == null)
            {
                return;
            }
            prefabToUse = applePrefab;
        }

        GameObject apple = Instantiate<GameObject>(prefabToUse);
        apple.transform.position = transform.position;

        // Set the appropriate tag based on which prefab was used
        if (prefabToUse == goldApplePrefab)
        {
            apple.tag = "Gold Apple";    // Make sure this tag exists in your Tags list
        }
        else
        {
            apple.tag = "Apple";
        }

        Invoke("DropApple", appleDropDelay);
    }


    void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if ( pos.x < -leftAndRightEdge ) {
            speed = Mathf.Abs( speed ); // Move right
            } 
        else if ( pos.x > leftAndRightEdge ) {
            speed = -Mathf.Abs( speed ); // Move left
        }
        //else if ( Random.value < changeDirChance ) {
        //    speed *= -1; // Change 
        //}
    }
    void FixedUpdate() {
        if ( Random.value < changeDirChance ) {
            speed *= -1; // Change direction
        }
    }
}