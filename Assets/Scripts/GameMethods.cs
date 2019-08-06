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
}
