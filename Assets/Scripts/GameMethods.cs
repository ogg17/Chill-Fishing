using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void GameOver()
    {
        CommonVariables.GamePlaying = false;
        CommonVariables.Score = 0;
        if(CommonVariables.OnVibration) Handheld.Vibrate();
        // CommonVariables.FishNumber = 0;
    }

    public void GameStart()
    {
        
    }

    public void GameStep()
    {
        if (CommonVariables.GamePlaying) CommonVariables.Score++;
    }

    public void GameStartInvoke()
    {
        if (!CommonVariables.GamePlaying)
        {
            CommonVariables.GamePlaying = true;
            EventController.GameEvents.startGame.Invoke();
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
}
