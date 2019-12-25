using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class CoinScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int stepProbably = 1;
    [SerializeField] private float depthCoin = 1.6f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private ParticleSystem baubles;
    [SerializeField] private GameObject core;
    [SerializeField] private DisappearTextScript disText;
    
    private int cost = 1;
    private Vector3 coinPos = new Vector3(0, 0, -2);
    private Vector3 move;
    private bool pickUp = true;

    private void Start()
    {
        StartCoroutine(Initialized());
        SpawningCoin();
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ZeroCoin);
        EventController.GameEvents.stepGame.AddListener(SpawningCoin);
    }
    private void SpawningCoin()
    {
        if (CommonVariables.GamePlaying && pickUp && Random.Range(0, 100) < 100)
        {
            core.SetActive(true);
            coinPos.y = CommonVariables.DepthHook - 3f;
            float randomX = Random.Range(0.6f, 1f);
            coinPos.x = Random.Range(0, 2) == 0 ? -0.68f*randomX : 0.68f*randomX;
            move.x = 0;
            transform.position = coinPos;
            pickUp = false;
        }
    }

    private void Update()
    {
        if (!pickUp && CommonVariables.GamePlaying)
        {
            move.y = speed * Time.deltaTime;
            transform.Translate(move);
            if (transform.position.y > CommonVariables.DepthHook + 3f)// || transform.position.y < CommonVariables.DepthHook - 3.1f) 
            {
                pickUp = true;
            }
        }
    }

    private void ZeroCoin()
    {
        cost = 1;
        pickUp = true;
        SpawningCoin();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CommonVariables.GamePlaying && !pickUp)
        {
            baubles.Play();
            core.SetActive(false);
            pickUp = true;
            CommonVariables.Gold += cost;
            CommonVariables.GoldSession += cost;
            EventController.GameEvents.pickUpCoin.Invoke();
            disText.SetGoldText(cost);
            cost++;
            SoundScript.sounds.PlaySound(SoundType.Bauble);
        }
    }
}
