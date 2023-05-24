using UnityEngine;

public class Batute : MonoBehaviour
{

    public float power = 2f;
    public float maxSpeed = 25f;

    void OnTriggerEnter(Collider collision)
    {
        var rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.velocity = -rb.velocity;
        if (rb.velocity.magnitude <= maxSpeed)
            rb.velocity *= power;

    }

}

