using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingRamp : MonoBehaviour
{
    private enum RampState { Closed, Open }
    private enum RampSide { Left, Right }
    private RampState CurrentState;
    [SerializeField] private RampSide CurrentSide;
    [SerializeField] private float force;
    private Vector3 openingDirection;
    private Vector3 closingDirection;
    private Rigidbody body;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        SetRamp();
    }
    
    private void SetRamp()
    {
        if (CurrentSide == RampSide.Left)
        {
            openingDirection = Vector3.forward;
            closingDirection = Vector3.back;
        }
        else if (CurrentSide == RampSide.Right)
        {
            openingDirection = Vector3.back;
            closingDirection = Vector3.forward;
        }
    }

    public void Activate()
    {
        if (CurrentState == RampState.Closed)
        {
            body.AddRelativeForce(openingDirection * force);
            CurrentState = RampState.Open;
        }
        else if (CurrentState == RampState.Open)
        {
            body.AddRelativeForce(closingDirection * force);
            CurrentState = RampState.Closed;
        }       
    }
}
