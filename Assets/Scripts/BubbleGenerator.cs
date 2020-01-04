using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private int bubbleCount = 5;
    [SerializeField] private int generatorTime;
    [SerializeField] private int probablyGeneration;
    
    private Vector3 coinPos = new Vector3(0, 0, -2);

    private void Start()
    {
        InvokeRepeating("GenerationBubble", generatorTime, generatorTime);
        StartCoroutine(Initialized());
    }
    
    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(DisableBonus);
    }

    private void GenerationBubble()
    {
        if (CommonVariables.GamePlaying && Random.Range(0, 1000) < probablyGeneration)
        {
            coinPos.y = CommonVariables.DepthHook - CommonVariables.CameraSize * 2 - 0.2f;
            float randomX = Random.Range(0.6f, 1f);
            coinPos.x = Random.Range(0, 2) == 0 ? -0.68f*randomX : 0.68f*randomX;
            Instantiate(bubble, coinPos, transform.rotation, transform);
        }
    }

    private void Update()
    {
        if(CommonVariables.isBonusX2 && DateTime.Now > CommonVariables.timeBonusX2 + TimeSpan.FromSeconds(5))
        {
            CommonVariables.bonusX2 = 1;
            CommonVariables.isBonusX2 = false;
            GameObjects.gameObjects.bonusX2.SetActive(false);
        }
        if(CommonVariables.isBonusX3 && DateTime.Now > CommonVariables.timeBonusX3 + TimeSpan.FromSeconds(5))
        {
            CommonVariables.bonusX3 = 1;
            CommonVariables.isBonusX3 = false;
            GameObjects.gameObjects.bonusX3.SetActive(false);
        }
    }

    private void DisableBonus()
    {
        if(CommonVariables.isBonusX2)
        {
            CommonVariables.bonusX2 = 1;
            CommonVariables.isBonusX2 = false;
            GameObjects.gameObjects.bonusX2.SetActive(false);
        }
        if(CommonVariables.isBonusX3)
        {
            CommonVariables.bonusX3 = 1;
            CommonVariables.isBonusX3 = false;
            GameObjects.gameObjects.bonusX3.SetActive(false);
        }
    }
}
