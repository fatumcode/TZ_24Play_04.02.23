using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    Placer groundPlacer;

    void Start()
    {
        groundPlacer = Placer.singleton;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            groundPlacer.SpawnObjects();
        }
    }
}
