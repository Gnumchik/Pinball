using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool
{
    private List<GameObject> _bonuse;
    private GameObject bonusPrefabs;

    public ObjectPool(int bonuseAmount)
    {
        _bonuse = new List<GameObject>();
        InitPool(bonuseAmount);
    }

    private void InitPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            _bonuse.Add(GameObject.Instantiate(bonusPrefabs));
        }
    }

    public GameObject Get(int index)
    {
        return _bonuse[index];
    }

    public void Return(GameObject gameObject)
    {
        _bonuse.Add(gameObject);
    }

    
}