using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private enum PlatformStates { AtStart, CoolingDown, AtAlternate }
    [SerializeField] private PlatformStates CurrentState;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 alternatePosition;
    private Vector3 direction;
    [SerializeField] private float force;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        AdjustPosition();
    }

    private void AdjustPosition()
    {       
        if (CurrentState == PlatformStates.AtStart)
        {
            direction = alternatePosition - transform.position;
            body.AddForce(direction * force);
            CurrentState = PlatformStates.AtAlternate;            
        }      
        else if (CurrentState == PlatformStates.AtAlternate)
        {
            direction = startPosition - transform.position;
            body.AddForce(direction * force);
            CurrentState = PlatformStates.AtStart;           
        }
              
    }
    
}
