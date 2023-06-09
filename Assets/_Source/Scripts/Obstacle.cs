using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float force;

    [SerializeField] private int chet;
    void Start()
    {
        force *= -1;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 vec = transform.position - collision.gameObject.transform.position;
        float distance = vec.magnitude;
        Vector3 vector = vec / distance;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(vector.x * force, vector.y * force, vector.z * force), ForceMode.Impulse);
    }

    public int GetChet() => chet;
}
