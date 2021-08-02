using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    private enum DoorStates { Down, Up }
    [SerializeField] private DoorStates CurrentState;
    private Rigidbody body;
    [SerializeField] private float force;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    
    public void Activate()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        if (CurrentState == DoorStates.Down)
        {
            body.AddForce(Vector3.up * force);
            CurrentState = DoorStates.Up;
        }
        else if(CurrentState == DoorStates.Up)
        {
            body.AddForce(Vector3.down * force);
            CurrentState = DoorStates.Down;
        }
    }
}
