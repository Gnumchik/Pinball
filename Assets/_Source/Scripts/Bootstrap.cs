using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private float restPosition = 0f;
    [SerializeField] private float pressedPOsition = -45f;
    [SerializeField] private float pressedPOsitionTow = 45f;
    [SerializeField] private float hitStrenght = 10000f;
    [SerializeField] private float flipperDamper = 150f;
    [SerializeField] private string inputName;
    [SerializeField] private string inputNameTow;
    [SerializeField] Flipper flipper;
    [SerializeField] Flipper flipperTow;


    [SerializeField] private GameObject[] bonuse;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] BonuseRndSpawn bonuseRndSpawn;

    [SerializeField] private float strengthMax;
    [SerializeField] private float strengthPlus;
    [SerializeField] Spring spring;

    [SerializeField] private GameObject prefabs;
    
    void Start()
    {
        flipper.Construct(restPosition,pressedPOsition,hitStrenght,flipperDamper,inputName);
        flipperTow.Construct(restPosition, pressedPOsitionTow, hitStrenght, flipperDamper, inputNameTow);
        bonuseRndSpawn.Construct(bonuse,spawnPoints, prefabs);
        spring.Construct(strengthMax, strengthPlus);
    }

    void Update()
    {

    }


}
