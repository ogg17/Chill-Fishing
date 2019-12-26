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
    [SerializeField] private int timeInterval = 5;

    private DateTime timeGive;
    private TimeSpan updateGiftTime = TimeSpan.Zero;
    private bool isGet;

    private void Start()
    {
        updateGiftTime = new TimeSpan(0, timeInterval, 0);
        if (PlayerPrefs.HasKey("timeM"))
            timeGive = new DateTime(PlayerPrefs.GetInt("timeY"), PlayerPrefs.GetInt("timeMo"), 
                PlayerPrefs.GetInt("timeD"), PlayerPrefs.GetInt("timeH"), PlayerPrefs.GetInt("timeM"),
                PlayerPrefs.GetInt("timeS"));
        
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
        CommonVariables.GoldGift = Random.Range(2, 16);
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
    
    private void Save(){ 
        PlayerPrefs.SetInt("timeS", timeGive.Second);
        PlayerPrefs.SetInt("timeM", timeGive.Minute);
        PlayerPrefs.SetInt("timeH", timeGive.Hour);
        PlayerPrefs.SetInt("timeD", timeGive.Day);
        PlayerPrefs.SetInt("timeMo", timeGive.Month);
        PlayerPrefs.SetInt("timeY", timeGive.Year);
        PlayerPrefs.Save();}
    private void OnApplicationPause(bool pauseStatus){if (pauseStatus == true) Save();}
    private void OnApplicationQuit() => Save();
}
