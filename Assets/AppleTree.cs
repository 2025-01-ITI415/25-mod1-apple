using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed=1f;
    //Distance where AppleTree turns Around
    public float leftAndRightEdge=10f;
    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections=0.1f;
    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops=1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //changing directions
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }else if (pos.x > leftAndRightEdge)//Move right
        {
            speed = -Mathf.Abs(speed);//move left
        }
    }
    private void FixedUpdate()
    {
        {
            //Changing Direction Randomly is now timed
            if(Random.value < chanceToChangeDirections)
            {
                speed *= -1;//change direction
            }
        }
    }
}
