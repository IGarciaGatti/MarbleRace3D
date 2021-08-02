using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingPad : MonoBehaviour
{   
    private enum LaunchStates { Standby, Launching }
    private LaunchStates CurrentState;
    private Rigidbody body;
    [SerializeField] private float startRotation;
    [SerializeField] private float force;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float cooldown;
    [SerializeField] private float currentCooldown;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        startRotation = transform.rotation.x;
    }
   
    void Update()
    {
        if (CurrentState == LaunchStates.Launching)
        {
            currentCooldown -= Time.deltaTime;
        }
        Turn();        
    }

    public void Launch()
    {
        CurrentState = LaunchStates.Launching;
        currentCooldown = cooldown;
    }
    
    private void Turn()
    {
        if (CurrentState == LaunchStates.Launching)
        {
            if (currentCooldown > 0)
            {
                body.AddTorque(direction * force);
            }
            else
            {
                body.AddTorque(-direction * force * force);                
                CurrentState = LaunchStates.Standby;                             
            }
        }
    }
}
