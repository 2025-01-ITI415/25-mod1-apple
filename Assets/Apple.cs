using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
// a
    public static float bottomY = -20f;
// b

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject );
// c
        }
    }
}
