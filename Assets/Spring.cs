using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private GameObject spring;

    private SpringJoint springJoint;

    void Start()
    {
        springJoint = spring.GetComponent<SpringJoint>() ;    
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if(springJoint.minDistance <= 4)
            {
                springJoint.minDistance += 0.05f;
            }
            //transform.position = new Vector3(3.09f, -2.478f, -5.204f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            springJoint.minDistance = 0;
        }
    }
}
