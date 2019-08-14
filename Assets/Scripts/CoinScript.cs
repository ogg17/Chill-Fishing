using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinScript : MonoBehaviour
{
    private void Start()
    {
        EventController.GameEvents.gameOver.AddListener(DestroyCoin);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hook"))
        {
            CommonVariables.Gold+=100;
            EventController.GameEvents.pickUpCoin.Invoke();
            DestroyCoin();
        }
    }

    public void DestroyCoin() => Destroy(gameObject);
}
