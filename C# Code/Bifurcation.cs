using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bifurcation : MonoBehaviour
{
    private enum Direction { Left, Right }
    [SerializeField] private Direction CurrentDirection;
    private Rigidbody body;
    [SerializeField] private float force;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void ChangeDirection()
    {
        if(CurrentDirection == Direction.Left)
        {
            body.AddTorque(Vector3.down * force);
            CurrentDirection = Direction.Right;
        }
        else if(CurrentDirection == Direction.Right)
        {
            body.AddTorque(Vector3.up * force);
            CurrentDirection = Direction.Left;
        }
    }
}
