using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAccessToSecondRoom : MonoBehaviour
{
    GameObject obj;
    public bool ventMoved = false;
    public float smoothTime = 14.3F;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("KeyHouse");
        allowVentMove check = obj.GetComponent<allowVentMove>();
        bool startMove = check.wallCanMove;

        
        if (startMove == true && ventMoved == false)
        {
            StartCoroutine(waitCoroutine());
        }

    }

    IEnumerator waitCoroutine()
    {
        Vector3 targetPosition = new Vector3(0, 0, 2);
        this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        yield return new WaitForSeconds(5);
        ventMoved = true;
    }
}
