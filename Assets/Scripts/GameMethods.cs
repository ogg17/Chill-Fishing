using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void GameOver()
    {
        CommonVariables.GamePlaying = false;
        CommonVariables.Score = 0;
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
        if (CommonVariables.CharacterShops[CommonVariables.CurrentPanel].BuyCharacter == false)
        {
            var count = 0;
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentPanel].IceShards[i] == true) count++;
            }

            if (count < CommonVariables.CharacterShops[CommonVariables.CurrentPanel].ShardCount && CommonVariables.Gold >=
                CommonVariables.CharacterShops[CommonVariables.CurrentPanel].ShardPrice)
            {
                CommonVariables.Gold -= CommonVariables.CharacterShops[CommonVariables.CurrentPanel].ShardPrice;
                var exit = false;
                while (!exit)
                {
                    int randomNum = Random.Range(0, CommonVariables.CharacterShops[CommonVariables.CurrentPanel].ShardCount);
                    if (CommonVariables.CharacterShops[CommonVariables.CurrentPanel].IceShards[randomNum] == false)
                    {
                        CommonVariables.CharacterShops[CommonVariables.CurrentPanel].IceShards[randomNum] = true;
                        exit = true;
                    }
                }
                CommonVariables.CharacterShops[CommonVariables.CurrentPanel].ShardPrice += 10;
            }
        }
        else
        {
            CommonVariables.EquippedSkin = CommonVariables.CurrentPanel;
        }
    }
}
