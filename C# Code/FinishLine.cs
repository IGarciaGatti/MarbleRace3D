using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : Checkpoint
{   
    private bool playerReachedEnd;
    private List<int> finishOrder;
    private int playerIndex;

    public bool PlayerReachedEnd => playerReachedEnd;
    public int PlayerIndex => playerIndex;
    public List<int> FinishOrder => finishOrder;


    void Start()
    {
        finishOrder = new List<int>();
        playerReachedEnd = false;
    }

    private void OnTriggerEnter(Collider sphereCollider)
    {
        CollisionWithSphere(sphereCollider);
    }

    public override void CollisionWithSphere(Collider sphereCollider)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (sphereCollider == spheres[i].GetComponent<Collider>())
            {               
                if (finishOrder.Count < 5)
                {
                    finishOrder.Add(i);
                    if (spheres[i].IsPlayer)
                    {
                        playerIndex = finishOrder.Count - 1;
                        playerReachedEnd = true;
                    }
                    spheres[i].SetRespawn(respawnPoint, fallLimit, sphereStopChecking);
                }
                
            }
        }
    }
   

}
