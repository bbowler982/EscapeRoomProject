using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allowBedBathAccess : MonoBehaviour
{
    public bool doorCanMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collision deteced with key2");
        if (col.gameObject.name == "keycubeUpstairs")
        {
            doorCanMove = true;
        }
    }
}
