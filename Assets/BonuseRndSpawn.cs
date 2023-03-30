using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonuseRndSpawn : MonoBehaviour
{
    public GameObject[] bonuse;
    public Transform[] spawnPoints;

    private int rand;
    private int randPosition;
    private float startTimeBtwnSpawns = 15;
    private float timeBtwSpawn;


    void Start()
    {
        timeBtwSpawn = startTimeBtwnSpawns;
    }

    void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            rand = Random.Range(0, bonuse.Length);
            randPosition = Random.Range(0, spawnPoints.Length);
            Instantiate(bonuse[rand], spawnPoints[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwnSpawns;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
