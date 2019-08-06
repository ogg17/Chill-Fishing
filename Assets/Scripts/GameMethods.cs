using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void GameOver()
    {
        CommonVariables.GamePlaying = false;
        CommonVariables.Score = 0;
        EventController.GameEvents.gameOver.Invoke();
    }

    public void GameStep()
    {
        if (CommonVariables.GamePlaying) CommonVariables.Score++;
        else
        {
            CommonVariables.GamePlaying = true;
            EventController.GameEvents.startGame.Invoke();
        }
    }
}
