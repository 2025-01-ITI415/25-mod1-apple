using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    void Start () {
        Invoke( "DropApple", 2f );
    }
    void DropApple() {
        GameObject apple = Instantiate<GameObject>(
        applePrefab ); 
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay );
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