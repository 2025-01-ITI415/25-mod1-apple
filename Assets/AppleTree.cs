using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject   applePrefab;

    // Speed at which the AppleTree moves
    public float        speed = 1f;

    // Distance at which the AppleTree moves
    public float        leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float        chanceToChangeDirections = 0.1f;

    // Rate at which Oranges will be instantiated
    public float        secondsBetweenOrangeDrops = 1f;

    // Start is called before the first frame update
    void Start()
    { // Dropping oranges every second
        
    }

    // Update is called once per frame
    void Update()
    { 
    // Basic Movement

    Vector3 pos = transform.position;

    pos.x += speed * Time.deltaTime;

    transform.position = pos;

    // Changing Direction
    }
}
