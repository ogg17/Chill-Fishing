using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void SetEmptyText()
    {
        _text.text = "";
    }
    public void SetScoreText()
    {
        if (CommonVariables.GamePlaying) _text.text = "Score: " + CommonVariables.Score;
    }
    public void SetGoldText()
    {
        _text.text = "Gold: " + CommonVariables.Gold;
    }
}
