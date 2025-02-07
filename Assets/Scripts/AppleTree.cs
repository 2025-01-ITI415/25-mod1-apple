using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header ("Set in Inspector")]
    
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject goldenapplePrefab;
    public GameObject poisonapplePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection = .01f;

    // Rate at which Apples will be instantiated
    public float appleDropDelay  = 1f;
    public float goldenAppleChance = .1f; // 10% chance for Golden Apple
    public float poisonAppleChance = .05f; // 5% chance for Poison Apple


    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second

        Invoke("DropApple", 2f);
    }

    void DropApple(){
        //GameObject appleToSpawn = (Random.value < goldenAppleChance) ? goldenapplePrefab : applePrefab;
        GameObject appleToSpawn;
        float randomValue = Random.value;
        if (randomValue < poisonAppleChance){
            appleToSpawn = poisonapplePrefab;  // 5% chance for poison apple
        }
        else if (randomValue < poisonAppleChance + goldenAppleChance)
        {
            appleToSpawn = goldenapplePrefab;  // 10% chance for golden apple
        }
        else
        {
            appleToSpawn = applePrefab;        // Otherwise, spawn a regular apple
        }

        GameObject apple = Instantiate(appleToSpawn);
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
