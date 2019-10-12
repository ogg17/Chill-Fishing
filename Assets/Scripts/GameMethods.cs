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
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            var count = 0;
            for (int i = 0; i < CommonVariables.MaxIcePieceCount; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1) count++;
            }

            if (count < CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8] && CommonVariables.Gold >=
                CommonVariables.CharacterShop[CommonVariables.CurrentPanel][9])
            {
                CommonVariables.Gold -= CommonVariables.CharacterShop[CommonVariables.CurrentPanel][9];

                bool exit = false;
                while (!exit)
                {
                    int randomNum = Random.Range(0, CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8]);

                    if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][randomNum] == 0)
                    {
                        CommonVariables.CharacterShop[CommonVariables.CurrentPanel][randomNum] = 1;
                        exit = true;
                    }
                }

                CommonVariables.CharacterShop[CommonVariables.CurrentPanel][9] += 10;
            }
        }
        else
        {
            CommonVariables.EquippedSkin = CommonVariables.CurrentPanel;
        }
    }
}
