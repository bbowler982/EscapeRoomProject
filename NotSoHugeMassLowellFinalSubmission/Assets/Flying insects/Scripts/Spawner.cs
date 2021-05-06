using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //public GameObject mySpawn;
    public GameObject insectsPrefab;
    //public GameObject goalPrefab;

    static int numInsects = 5;
    public static GameObject[] allInsects = new GameObject[numInsects];

    public int maxHeight;
    Vector3 spawnpos;
    public static Vector3 goalPos = Vector3.zero;
    public static int insectRange = 10;

    // Use this for initialization
    void Start ()
    {
        //goalPos = mySpawn.transform.position;
        for (int i = 0; i< numInsects; i++)
        {
            spawnpos = transform.position;
            spawnpos.x += Random.Range(-insectRange, +insectRange);
            spawnpos.z += Random.Range(-insectRange, +insectRange);
            spawnpos.y = Random.Range(Terrain.activeTerrain.SampleHeight(spawnpos), maxHeight);
           // if (spawnpos.y > maxHeight)
           // {
            //	spawnpos.y = maxHeight;
           // }
            allInsects[i] = (GameObject)Instantiate(insectsPrefab, spawnpos, Quaternion.identity);
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Random.Range(0,10000)<50)
        {
            goalPos = transform.position;
            goalPos.x += Random.Range(-insectRange, +insectRange);
            goalPos.z += Random.Range(-insectRange, +insectRange);
            goalPos.y = Random.Range(Terrain.activeTerrain.SampleHeight(spawnpos), maxHeight);
            // if (goalPos.y > maxHeight)
            //{
            //	goalPos.y = maxHeight;
           // }
            //goalPrefab.transform.position = goalPos;
        }
        Debug.Log(goalPos);
    }
}
