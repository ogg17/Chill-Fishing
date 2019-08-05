using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void StartGame()
    {
        if (!CommonVariables.GamePlaying) CommonVariables.GamePlaying = true;
    }

    public void GameOver()
    {
        CommonVariables.GamePlaying = false;
        CommonVariables.Score = 0;
    }

    public void GameStep()
    {
        if (CommonVariables.GamePlaying) CommonVariables.Score++;
    }
}
