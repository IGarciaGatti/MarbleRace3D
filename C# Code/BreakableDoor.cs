using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableDoor : MonoBehaviour
{
    private Rigidbody body;
    private HingeJoint joint;
    private bool isBroken;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        joint = GetComponent<HingeJoint>();
    }
    
    void Update()
    {
        CheckIfBroken();
    }

    private void CheckIfBroken()
    {
        if (!isBroken)
        {
            if(joint == null)
            {
                body.useGravity = true;
                isBroken = true;
            }
        }
    }
}
