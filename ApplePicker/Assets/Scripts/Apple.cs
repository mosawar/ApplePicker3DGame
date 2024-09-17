using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            //deletes the apple that are below the -20f y to keep it from having too many apples
            Destroy(this.gameObject);

            // get a reference to the applepicker component of main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // call the public applemissed() method of apScript
            apScript.AppleMissed();
        }
    }
}
