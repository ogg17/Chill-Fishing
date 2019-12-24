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
        timeGive = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
            DateTime.Now.Hour, PlayerPrefs.GetInt("timeM"), PlayerPrefs.GetInt("timeS"));
        StartCoroutine(Initialized());
    }
    
    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        UpdateGift();
    }
    public void GiveGift()
    {
        isGet = true;
        goldParticle.Play();
        cloudParticle.Play();
        gift.SetActive(false);
        penguin.SetFirstState();
        cloudZzz.SetActive(true);
        CommonVariables.GoldGift = Random.Range(10, 51);
        CommonVariables.Gold += CommonVariables.GoldGift;
        timeGive = DateTime.Now;
    }
    public void UpdateGift()
    {
        if (DateTime.Now > timeGive + updateGiftTime)
        {
            gift.SetActive(true);
            cloudZzz.SetActive(false);
            penguin.SetSecondState();
            isGet = false;
        }
    }
    
    private void Save(){ PlayerPrefs.SetInt("timeS", timeGive.Second);
        PlayerPrefs.SetInt("timeM", timeGive.Minute);PlayerPrefs.Save();}
    private void OnApplicationPause(bool pauseStatus){if (pauseStatus == true) Save();}
    private void OnApplicationQuit() => Save();
}
