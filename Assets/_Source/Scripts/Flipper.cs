using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _restPosition = 0f;
    private float _pressedPOsition = 45f;
    private float _hitStrenght = 10000f;
    private float _flipperDamper = 150f;
    private string _inputName;

    

    HingeJoint hinge;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = _hitStrenght;
        spring.damper = _flipperDamper;

        if(Input.GetAxis(_inputName) == 1)
        {
            spring.targetPosition = _pressedPOsition;
        }
        else
        {
            spring.targetPosition = _restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }

    public void Construct(float restPosition, float pressedPOsition, float hitStrenght, float flipperDamper, string inputName)
    {
        _restPosition = restPosition;
        _pressedPOsition = pressedPOsition;
        _hitStrenght = hitStrenght;
        _flipperDamper = flipperDamper;
        _inputName = inputName;
    }
}
