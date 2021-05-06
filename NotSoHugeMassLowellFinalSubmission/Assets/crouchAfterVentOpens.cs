using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchAfterVentOpens : MonoBehaviour
{
    public bool enteredSecondRoom = false;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        obj = GameObject.Find("vent");
        getAccessToSecondRoom check = obj.GetComponent<getAccessToSecondRoom>();
        bool startCrouch = check.ventMoved;

        if(startCrouch && enteredSecondRoom == false)
        {
            StartCoroutine(waitCoroutine());
        }

    }

    IEnumerator waitCoroutine()
    {
        Vector3 crouchScale = new Vector3(transform.localScale.x, 0.7f, transform.localScale.z);
        Vector3 standingScale = new Vector3(transform.localScale.x, 1.0f, transform.localScale.z);
        this.transform.localScale = crouchScale;
        yield return new WaitForSeconds(15);
        this.transform.localScale = standingScale;
        enteredSecondRoom = true;
    }
}
