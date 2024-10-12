using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{

    // This class component is used by characters

    public float distance;
    public GameObject target;
    public int rank;

    void Update()
    {

        CalculateDistance();

    }

    void CalculateDistance()
    {

        distance = Vector3.Distance(transform.position, target.transform.position); // It calculates the distance between stickman and end.

    }

}
