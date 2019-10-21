using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFish : MonoBehaviour
{
    [SerializeField] private GameObject[] fish = new GameObject[1];
    [SerializeField] private int maxFish;

    private void Start()
    {
        for(int i = 0; i < maxFish; i++)
        {
            Instantiate(fish[Random.Range(0, fish.Length)]);
        }
    }
}
