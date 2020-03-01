using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void GameOver()
    {
        if(CommonVariables.GamePlaying) SoundCenter.sounds.PlayLose();
        CommonVariables.GamePlaying = false;
        if(CommonVariables.OnVibration) Handheld.Vibrate();
        if(CommonVariables.Record < CommonVariables.Score) CommonVariables.Record = CommonVariables.Score;
        Debug.Log("Game Over!");
    }

    public void GameStart()
    {
        CommonVariables.GoldSession = 0;
        CommonVariables.Score = 0;
    }

    public void GameStep()
    {
        if (CommonVariables.GamePlaying) CommonVariables.Score++;
        EventController.GameEvents.stepGame.Invoke();
       // SoundScript.sounds.PlaySound(SoundType.Lose);
    }

    public void GameStartInvoke()
    {
        if (!CommonVariables.GamePlaying)
        {
            CommonVariables.GamePlaying = true;
            EventController.GameEvents.startGame.Invoke();
            SoundCenter.sounds.PlayStart();
        }
    }
    public void BuyIcePiece()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            var count = 0;
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == true) count++;
            }

            if (count < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount && CommonVariables.Gold >=
                CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardPrice)
            {
                CommonVariables.Gold -= CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardPrice;
                var exit = false;
                while (!exit)
                {
                    int randomNum = Random.Range(0, CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount);
                    if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[randomNum] == false)
                    {
                        CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[randomNum] = true;
                        exit = true;
                    }
                }
                CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardPrice += 10;
            }
        }
        else CommonVariables.EquippedSkin = CommonVariables.CurrentIndexPanel;
    }

    public void SetLanguage()
    {
        if (CommonVariables.GameLanguage == SystemLanguage.English)
            CommonVariables.GameLanguage = SystemLanguage.Russian;
        else CommonVariables.GameLanguage = SystemLanguage.English;
        EventController.GameEvents.setLanguage.Invoke();
    }
    public void SetMusic()
    {
        CommonVariables.OnMusic = !CommonVariables.OnMusic;
        
    }

    public void SetSound()
    {
        CommonVariables.OnSound = !CommonVariables.OnSound;
    }

    public void SetVibration()
    {
        CommonVariables.OnVibration = !CommonVariables.OnVibration;
    }
    
    public void invokeChangedPanels()
    {
        EventController.GameEvents.updatePanel.Invoke();
    }

    public void OpenPolicy()
    {
        Application.OpenURL("https://sites.google.com/view/chill-fishing-privacy-policy/");
    }

    public void FirstOpenGuide()
    {
        PlayerPrefs.SetInt("guide", 1);
        PlayerPrefs.Save();
    }
}
