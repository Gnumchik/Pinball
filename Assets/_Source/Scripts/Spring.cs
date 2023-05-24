using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private float _strengthMax;
    private float _strengthPlus;

    //[SerializeField] private Spring _spring;

    private float _totalStrength;
    private Rigidbody ballRb;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            AddStrength();

        if (Input.GetKeyUp(KeyCode.Space))
            Release();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            ballRb = collision.gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            ballRb = null;
    }

    public void AddStrength()
    {
        if (_totalStrength < _strengthMax)
            _totalStrength += _strengthPlus;
    }

    public void Release() => ballRb?.AddForce(0, _totalStrength, 0, ForceMode.Impulse);


    public void Construct(float strengthMax, float strengthPlus)
    {
        _strengthMax = strengthMax;
        _strengthPlus = strengthPlus;
    }
}