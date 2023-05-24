using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonuseRndSpawn : MonoBehaviour
{
    private GameObject[] _bonuse;
    private Transform[] _spawnPoints;

    private int _rand;
    private int _randPosition;
    private float _startTimeBtwnSpawns = 15;
    private float _timeBtwSpawn;


    void Start()
    {
        _timeBtwSpawn = _startTimeBtwnSpawns;
    }

    void Update()
    {
        if(_timeBtwSpawn <= 0)
        {
            _rand = Random.Range(0, _bonuse.Length);
            _randPosition = Random.Range(0, _spawnPoints.Length);
            Instantiate(_bonuse[_rand], _spawnPoints[_randPosition].transform.position, Quaternion.identity);
            _timeBtwSpawn = _startTimeBtwnSpawns;
        }
        else
        {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }

    public void Construct(GameObject[] bonuse, Transform[] spawnPoints)
    {
        _bonuse = bonuse;
        _spawnPoints = spawnPoints;
    }
}
