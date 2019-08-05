using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMethods : MonoBehaviour
{
    public void StartGame()
    {
        CommonVariables.GamePlaying = true;
    }

    public void ScorePlus()
    {
        CommonVariables.Score++;
    }

    public void ScoreZero()
    {
        CommonVariables.Score = 0;
    }
}
