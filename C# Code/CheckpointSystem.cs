using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    [SerializeField] private Checkpoint[] checkpoints;   
    private Checkpoint currentCheckpoint;
    private Checkpoint nextCheckpoint;
    private FinishLine finalCheckpoint;
    private int index;
    private List<Sphere> spheres;
    private List<float> sphereDistance;
    private List<int> sphereOrder;

    public List<int> SphereOrder => sphereOrder;


    void Start()
    {
        currentCheckpoint = checkpoints[index];
        nextCheckpoint = checkpoints[index + 1];
        finalCheckpoint = (FinishLine) checkpoints[checkpoints.Length - 1];
        sphereDistance = new List<float>();
        sphereOrder = new List<int>();
    }
    
    void Update()
    {
        sphereOrder.Clear();
        UpdateCurrentCheckpoint();
        AdjustSphereOrder();
    }
   

    public void SetSpheres(List<Sphere> spheres)
    {
        this.spheres = spheres;
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].SetSpheres(spheres);
        }
    }

    public void UpdateCurrentCheckpoint()
    {       
        if (nextCheckpoint.CurrentState == CheckpointState.Active)
        {
            currentCheckpoint = nextCheckpoint;              
            if (index < checkpoints.Length - 1)
            {                                               
                index += 1;
                nextCheckpoint = checkpoints[index];              
            }          
        }
    }
      

    private void UpdateDistance()
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            sphereDistance.Add(Vector3.Distance(nextCheckpoint.transform.position, spheres[i].transform.position));           
        }
        sphereDistance.Sort();        
    }

    public void AdjustSphereOrder()
    {
        UpdateDistance();
        float number = 0;
        for (int i = 0; i < spheres.Count; i++)
        {
            number = Vector3.Distance(nextCheckpoint.transform.position, spheres[i].transform.position);
            for (int j = 0; j < sphereDistance.Count; j++)
            {
                if (number == sphereDistance[j])
                {
                    sphereOrder.Add(j);                   
                }               
            }
        }       
        sphereDistance.Clear();       
    }
}
