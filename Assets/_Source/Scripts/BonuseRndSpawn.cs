 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonuseRndSpawn : MonoBehaviour
{
    private GameObject[] _bonuse;
    private Transform[] _spawnPoints;

    private GameObject _prefabs;
    private Transform _spawnPositionOnScen;

    private ObjectPool objectPool;

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
            GameObject gameObjects = objectPool.GetFreeElement();
            gameObjects.transform.position = _spawnPoints[_randPosition].position;

            _timeBtwSpawn = _startTimeBtwnSpawns;
        }
        else
        {
            _timeBtwSpawn -= Time.deltaTime;
        }
    }

    public void Construct(GameObject[] bonuse, Transform[] spawnPoints, GameObject prefabs)
    {
        _bonuse = bonuse;
        _spawnPoints = spawnPoints;
        _prefabs = prefabs;
        objectPool = new ObjectPool(6, _prefabs);
    }
}
