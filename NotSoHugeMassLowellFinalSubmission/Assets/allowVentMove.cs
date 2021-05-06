using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allowVentMove : MonoBehaviour
{
    public bool wallCanMove = false;
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
        Debug.Log("collision deteced with key");
        if(col.gameObject.name == "keycube")
        {
            wallCanMove = true;
        }
    }

    /*void onTriggerEnter(Collider col)
    {
        if(col.name == "KeyHouse")
        {
            wallCanMove = true;
        }
    }*/
}
