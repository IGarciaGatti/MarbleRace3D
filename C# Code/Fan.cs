using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] private float distanceFromPivot;
    [SerializeField] private Vector3 force;
    [SerializeField] private float angle;
    private Vector3 torque;
    private float angleSin;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        angleSin = Mathf.Sin(angle);
    }
   
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        torque = distanceFromPivot * force * angleSin;
        body.AddTorque(torque);
    }
}
