using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
            
            // Add null check for Camera.main
            if (Camera.main != null) {
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                if (apScript != null) {
                    apScript.AppleMissed();
                }
            }
        }
    }
}