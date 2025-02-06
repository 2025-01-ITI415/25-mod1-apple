using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header ("Set in Inspector")]
    
    // Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection = .01f;

    // Rate at which Apples will be instantiated
    public float appleDropDelay  = 1f;


    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second

        Invoke("DropApple", 2f);
    }

    void DropApple(){
         GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
    // Update is called once per frame
    void Update()
    {
        // Move the AppleTree
        Vector3 pos = transform.position;  // Get current position
        pos.x += speed * Time.deltaTime;   // Move based on speed
        transform.position = pos;          // Apply new position

        // Change direction at boundaries
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);  // Move right
        } else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);  // Move left
        //} else if (Random.value < chanceToChangeDirection){ 
        //    speed *= -1;  // Randomly change direction
        }
    }
    void FixedUpdate(){
        if (Random.value < chanceToChangeDirection){
            speed *= -1;  // Randomly change direction
        }
    }
}
