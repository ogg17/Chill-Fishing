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

    public void SetIcePieceCount()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.MaxIcePieceCount; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1) count++;
            }
            _text.text = count + "/5";
        }
        else _text.text = "";
    }

    public void SetNameCharacter()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 1)
        {
            _text.text = GameString.gameString.names[CommonVariables.CurrentPanel];
        }
        else _text.text = "";
    }
}
