using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AppleTree : MonoBehaviour {
    [Header("Set In Inspector")]
    //prefab for multiplying da apples
public GameObject applePrefab;
//speed apple tree move
public float speed = 1f;
public float leftandRightEdge = 20f;
//chance that tree changed directions 
public float chancetoChangeDirections = 0.1f;
//rate at which apple will be dropped
public float secondsBetweenAppleDrops = 1f;

void Start () {
    //dropping apples every sec
Invoke ( "DropApple" , 2f); // a
}
void DropApple() { //b
GameObject apple = Instantiate<GameObject>( applePrefab ); //c
    apple.transform.position = transform.position; //d
Invoke( "DropApple", secondsBetweenAppleDrops); //e
}
void Update () {
    //basic movement
Vector3 pos = transform.position; // b
pos.x += speed * Time.deltaTime; // c
transform.position = pos; // d

   //CHANGE THE BASIC MOVEMENTS
    //CHANGE OF DIRECTION 
if ( pos.x < -leftandRightEdge ){
    speed = Mathf.Abs(speed); // move right b
} else if ( pos.x > leftandRightEdge ) { // c
speed = -Mathf.Abs(speed); // move left c
} 
}
void FixedUpdate() {
    //changed direction randomly that is time based
    if ( Random.value < chancetoChangeDirections ) { // b
    speed *= -1; //change direction
}
}
}

