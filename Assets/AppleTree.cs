using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject applePrefab;

    //Apple Tree speed
    public float speed = 1f;

    //Distance AppleTree turns around
    public float leftAndRightEdge = 20f;

    //Chance that the AppleTree will chance direction
    public float changeDirChance = 0.1f;

// Second between apple drop instantiations
    public float appleDropDelay = 1f;

    public GameObject ApplePrefab { get => applePrefab; set => applePrefab = value; }


    // Start is called before the first frame update
    void Start()
    {
        //Apples dropping every second
        Invoke("DropApple", 2f);
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>( ApplePrefab );
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay );
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        } 
    }
    void FixedUpdate(){
        if (Random.value < changeDirChance){
            speed *= -1;
        }
    }
}
