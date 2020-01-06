using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GiftAdScript : MonoBehaviour
{
    [SerializeField] private GameObject gift;
    [SerializeField] private DisappearTextScript disText;
    [SerializeField] private ButtonScript buttonGift;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private TextScript goldText;
    [SerializeField] private ParticleSystem goldParticle;
    [SerializeField] private ParticleSystem cloudParticle;
    [SerializeField] private int rewardIntervalMinutes = 5;
    [SerializeField] private int minReward = 50;
    [SerializeField] private int maxReward = 90;

    private DateTime timeGive;
    private TimeSpan updateGiftTime = TimeSpan.Zero;
    private bool isGet;

    private void Start()
    {
        updateGiftTime = TimeSpan.FromMinutes(rewardIntervalMinutes);
        if (PlayerPrefs.HasKey("timeMa"))
            timeGive = new DateTime(PlayerPrefs.GetInt("timeYa"), PlayerPrefs.GetInt("timeMoa"), 
                PlayerPrefs.GetInt("timeDa"), PlayerPrefs.GetInt("timeHa"), PlayerPrefs.GetInt("timeMa"),
                PlayerPrefs.GetInt("timeSa"));
        
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
        SoundCenter.sounds.PlayCoin();
        gift.SetActive(false);
        CommonVariables.GoldGift = Random.Range(minReward, maxReward);
        CommonVariables.Gold += CommonVariables.GoldGift;
        disText.SetGoldText();
        goldText.SetGoldText();
        timeGive = DateTime.Now;
    }

    public void OpenCheckWindow()
    {
        checkWindow.SetActive(true);
    }
    public void UpdateGift()
    {
        if (DateTime.Now > timeGive + updateGiftTime)
        {
            gift.SetActive(true);
            isGet = false;
        }
        else
        {
            gift.SetActive(false);
        }
        if(!CommonVariables.GamePlaying) buttonGift.ActivateButton();
    }
    
    private void Save(){ 
        PlayerPrefs.SetInt("timeSa", timeGive.Second);
        PlayerPrefs.SetInt("timeMa", timeGive.Minute);
        PlayerPrefs.SetInt("timeHa", timeGive.Hour);
        PlayerPrefs.SetInt("timeDa", timeGive.Day);
        PlayerPrefs.SetInt("timeMoa", timeGive.Month);
        PlayerPrefs.SetInt("timeYa", timeGive.Year);
        PlayerPrefs.Save();}
    private void OnApplicationPause(bool pauseStatus){if (pauseStatus == true) Save();}
    private void OnApplicationQuit() => Save();
}
