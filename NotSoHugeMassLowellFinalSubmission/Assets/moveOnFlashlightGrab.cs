using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnFlashlightGrab : MonoBehaviour
{
    public bool openHallway = false;
    GameObject obj;
    public float smoothTime = 10.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("Flashlight");
        OVRGrabbable flashlight = obj.GetComponent<OVRGrabbable>();

        bool grabbedOnce = flashlight.isGrabbed;
        if (grabbedOnce == true && openHallway == false)
        {
            Vector3 targetPosition = new Vector3(.0518f, transform.position.y, transform.position.z);
            this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            openHallway = true;
        }
    }
}
