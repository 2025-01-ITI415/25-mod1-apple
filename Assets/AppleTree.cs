using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")]
    //A Prefab for instantiating Apples
    public GameObject applePreFab;

    //Apple Tree's schmovement speed.
    public float speed = 1f;

    //Distance where Apple Tree turns around
    public float leftAndRightEdge = 10f;

    //Chance that Apple Tree will turn around before edge
    public float changeDirChance = 0.1f;

    //Seconds between Apple Instantiations
    public float appleDropDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //Start Dropping Apples
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move Right
        }else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move Left
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePreFab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
}
