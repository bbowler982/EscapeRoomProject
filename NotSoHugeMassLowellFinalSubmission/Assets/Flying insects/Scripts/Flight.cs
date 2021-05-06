using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

    public float speed = 1.5f;
    public float rotationSpeed = 1 ;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 4.0f;
    public float maxSpeed = 3.0f;
    public float minSpeed = 1.1f;
    public Vector3 spawnpos;


    bool turning = false;

	// Use this for initialization
	void Start ()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        spawnpos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (speed>maxSpeed)
        {
            speed = maxSpeed;
        }

        if (Vector3.Distance(transform.position, spawnpos) >= Spawner.insectRange)
        {
            turning = true;
        }
        else
            turning = false;

        if (turning)
        {
            Vector3 direction = spawnpos - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(minSpeed, maxSpeed);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
                ApplyRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
	}
    void ApplyRules()
    {
        GameObject[] gos;
        gos = Spawner.allInsects;
        Vector3 vcentre = spawnpos;
        Vector3 vavoid = spawnpos;
        float gSpeed = 0.1f;

        Vector3 goalPos = Spawner.goalPos;

        float dist;

        int groupSize = 0;
        foreach(GameObject go in gos)
        {
            if(go !=this.gameObject)
            { 
              dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flight anotherFlock = go.GetComponent<Flight>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize>0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != spawnpos)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
    }
}
