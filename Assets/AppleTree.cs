using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    // a
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start () {
    // Start dropping apples
    // b
    }

    void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
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
        // Random direction changes are now time-based due to
        if ( Random.value < changeDirChance ) {
            speed *= -1; // Change direction
        }
    }
}