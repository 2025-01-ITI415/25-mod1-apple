using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour {
[Header("Set In Inspector")]
public static float bottomY = -20f; // a
void Update () {
if ( transform.position.y < bottomY ) { //a
Destroy( this.gameObject ); //b
//get a refrence to this apple picker componet of main camera 
ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); //b
//call the public appledestroyed() method apScript
apScript.AppleDestroyed(); //c
}
}
}

