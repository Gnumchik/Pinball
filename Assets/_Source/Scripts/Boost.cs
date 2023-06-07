using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    [SerializeField] private float force;


    private void OnTriggerEnter(Collider other)
    {
        Vector3 vec = transform.position - other.gameObject.transform.position;
        float distance = vec.magnitude;
        Vector3 vector = vec / distance;
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, vector.y * force, 0), ForceMode.Impulse);
    }
}
