using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool
{
    private List<GameObject> _pool;
    private GameObject _bonusPrefabs;

    public ObjectPool(int bonuseAmount , GameObject prefabsBonus)
    {
        _bonusPrefabs = prefabsBonus;

        CreatePool(bonuseAmount);
    }

    public GameObject GetFreeElement()
    {
        if(HasFreeElement(out GameObject element))
        {
            return element;
        }
        else
        {
            return CreaateObject(false);
        }
    }


    private void CreatePool(int count)
    {
        _pool = new List<GameObject>();
        
        for(int i =0; i < count; i++)
        {
            CreaateObject();
        }
    }

    private GameObject CreaateObject(bool isActiveByDefolt = false)
    {
        Debug.Log(_bonusPrefabs);   

        GameObject bonus = GameObject.Instantiate(_bonusPrefabs);
        _bonusPrefabs.SetActive(isActiveByDefolt);
        _pool.Add(bonus);
        return bonus;
    }

    private bool HasFreeElement(out GameObject element)
    {
        for(int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].gameObject.activeInHierarchy)
            {
                element = _pool[i];
                _pool[i].gameObject.SetActive(true);

                return true;
            }
        }

        element = null;
        return false;
    }
}
