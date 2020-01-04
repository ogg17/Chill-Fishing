using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjects : MonoBehaviour
{
    [SerializeField] public GameObject bonusX2;
    [SerializeField] public GameObject bonusX3;
    [SerializeField] public GameObject goldFish;
    [SerializeField] public GameObject bonusPart;

    [Space(10)] 
    [SerializeField] public GameObject bubble;
    [SerializeField] public GameObject bubbleGenerator;
    
    public static GameObjects gameObjects = null;
    private void Start()
    {
        if (gameObjects == null)
        {
            gameObjects = this;
        }
        else if (gameObjects == this)
        {
            Destroy(gameObject);
        }
    }
}
