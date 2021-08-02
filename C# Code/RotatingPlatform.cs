using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private enum WheelDirection { Forward, Backward }
    private enum BladeState { NotInUsage, InUsage }
    private WheelDirection CurrentDirection;
    [SerializeField] private BladeState CurrentBladeState;
    private Rigidbody body;
    [SerializeField] private Rigidbody bladeBody;
    [SerializeField] private float bladeTorqueMultiplier;
    [SerializeField] private float distanceFromPivot;
    [SerializeField] private Vector3 force;
    [SerializeField] private float angle;
    private float angleSin;
    private Vector3 torque;
    private Vector3 bladeTorque;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        angleSin = Mathf.Sin(angle);
    }

    void Update()
    {
        Rotation();
    }

    public void ChangeDirection()
    {
        if (CurrentDirection == WheelDirection.Forward)
        {
            CurrentDirection = WheelDirection.Backward;
        }
        else if (CurrentDirection == WheelDirection.Backward)
        {
            CurrentDirection = WheelDirection.Forward;
        }
    }

    private void Rotation()
    {        
        if (CurrentDirection == WheelDirection.Forward)
        {
            torque = distanceFromPivot * force * angleSin;
            bladeTorque = -torque * bladeTorqueMultiplier;
        }
        else if (CurrentDirection == WheelDirection.Backward)
        {
            torque = distanceFromPivot * -force * angleSin;
            bladeTorque = -torque * bladeTorqueMultiplier;
        }

        body.AddTorque(torque);
        if (CurrentBladeState == BladeState.InUsage)
        {
            bladeBody.AddTorque(bladeTorque);
        }
        
    }
}
