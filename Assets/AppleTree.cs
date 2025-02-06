using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject ApplePrefab;

    //Speed of AppleTree
    public float speed = 1f;

    //Distance wehre AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change direction
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start() {
        //Begin Dropping Apples
        Invoke( "DropApple", 2f );
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(ApplePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void Update() {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); //Move Right
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); //Move Left
        }
    }
    void FixedUpdate() {
        if (Random.value < changeDirChance) {
            speed *= -1;
        }
    }
}
