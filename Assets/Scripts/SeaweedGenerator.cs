using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeaweedGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> seaweed;
    [SerializeField] private int weedCount = 5;

    private void Start()
    {
        for (int i = 0; i < weedCount; i++)
        {
            Instantiate(seaweed[Random.Range(0,seaweed.Count)], this.transform);
        }
    }
}
