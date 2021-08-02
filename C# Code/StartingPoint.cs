using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    [SerializeField] private List<Vector3> firstArrangement;
    [SerializeField] private List<Vector3> secondArrangement;
    [SerializeField] private List<Vector3> thirdArrangement;
    private List<Vector3> currentArrangement;

    public List<Vector3> CurrentArrangement => currentArrangement;

    public void SetCurrentArrangement()
    {
        float randomValue = Random.Range(0, 3);
        if(randomValue == 0)
        {
            currentArrangement = firstArrangement;
        }
        else if (randomValue == 1)
        {
            currentArrangement = secondArrangement;
        }
        else if(randomValue == 2)
        {
            currentArrangement = thirdArrangement;
        }

        Shuffle();
    }

    private void Shuffle()
    {
        float count = currentArrangement.Count;
        float last = currentArrangement.Count - 1;
        for (int i = 0; i < last; i++)
        {
            int random = (int) Random.Range(i, count);
            Vector3 tmp = currentArrangement[i];
            currentArrangement[i] = currentArrangement[random];
            currentArrangement[random] = tmp;
        }
    }
}
