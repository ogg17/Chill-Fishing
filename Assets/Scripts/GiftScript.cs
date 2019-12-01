using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GiftScript : MonoBehaviour
{
    [SerializeField] private GameObject gift;
    [SerializeField] private SpriteScript penguin;
    [SerializeField] private GameObject cloudZzz;
    [SerializeField] private ParticleSystem goldParticle;
    [SerializeField] private ParticleSystem cloudParticle;
    [SerializeField] private int timeInterval = 10;

    private DateTime timeGive;
    private TimeSpan updateGiftTime = TimeSpan.Zero;
    private bool isGet;

    private void Start()
    {
        updateGiftTime = new TimeSpan(0, 0, timeInterval);
    }

    public void GiveGift()
    {
        isGet = true;
        goldParticle.Play();
        cloudParticle.Play();
        gift.SetActive(false);
        penguin.SetStateImage();
        cloudZzz.SetActive(true);
        CommonVariables.GoldGift = Random.Range(10, 51);
        CommonVariables.Gold += CommonVariables.GoldGift;
        timeGive = DateTime.Now;
    }
    public void UpdateGift()
    {
        if (isGet && DateTime.Now > timeGive + updateGiftTime)
        {
            gift.SetActive(true);
            cloudZzz.SetActive(false);
            penguin.SetStateImage();
            isGet = false;
        }
    }
}
