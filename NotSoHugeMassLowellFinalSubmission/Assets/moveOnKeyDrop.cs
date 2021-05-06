using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnKeyDrop : MonoBehaviour
{

    GameObject obj;
    public bool doorMoved = false;
    public float smoothTime = 14.3F;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("KeyHouse2");
        allowBedBathAccess check = obj.GetComponent<allowBedBathAccess>();
        bool startMove = check.doorCanMove;

        if (startMove == true && doorMoved == false)
        {
            Vector3 targetPosition = new Vector3(transform.position.y, transform.position.x, 0.03f);
            this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            doorMoved = true;
        }

    }

}
