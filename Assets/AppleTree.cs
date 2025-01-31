using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Apple Tree speed
    public float speed = 1f;

    //Distance AppleTree turns around
    public float leftAndRightEdge = 20f;

    //Chance that the AppleTree will chance direction
    public float chanceToChangeDirection = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        //Apples dropping every second
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
        } else if (Random.value < chanceToChangeDirection){
            speed *= -1;
        }
    }
}
