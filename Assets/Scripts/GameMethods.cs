using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void GameOver()
    {
        CommonVariables.GamePlaying = false;
        CommonVariables.Score = 0;
        CommonVariables.FishNumber = 0;
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

    public void TestAddIcePiece()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            var count = 0;
            for (int i = 0; i < CommonVariables.MaxIcePieceCount; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1) count++;
            }

            if (count < 5) CommonVariables.CharacterShop[CommonVariables.CurrentPanel][Random.Range(0, 5)] = 1;
            else
            {
                CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] = 1;
            }
        }
    }
}
