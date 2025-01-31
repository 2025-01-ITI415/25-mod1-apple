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
    public float chanceDirChance = 0.1f;

    //Seconds between Apple Instantiations
    public float appleDropDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //Start Dropping Apples
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement


        //Changing Direction
    }
}
