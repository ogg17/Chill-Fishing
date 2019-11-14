using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private int stepProbably = 1;
    [SerializeField] private float depthCoin = 1.6f;
    
    private int probably = 1;
    private int cost = 1;
    private Vector2 coinPos;

    private void Start()
    {
        StartCoroutine(Initialized());
        SpawningCoin();
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ZeroCoin);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hook"))
        {
            CommonVariables.Gold += cost;
            CommonVariables.GoldSession += cost;
            cost++;
            CommonVariables.CoinPos = 2;
            SpawningCoin();
            EventController.GameEvents.pickUpCoin.Invoke();
        }
    }
    private void SpawningCoin()
    {
        var x = Random.Range(0.04f, 1f);
        probably = Mathf.RoundToInt(Mathf.Sqrt(x) * 50);
        var coinPosY = CommonVariables.DepthHook - probably * 0.2f;
        coinPos.y = coinPosY;
        transform.position = coinPos;
        CommonVariables.CoinPos = coinPosY;
    }

    private void ZeroCoin()
    {
        cost = 1;
        SpawningCoin();
    }
}
