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

    public void SetIceShardCount()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8]; i++)
            {
                if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][i] == 1) count++;
            }
            _text.text = count + "/" + CommonVariables.CharacterShop[CommonVariables.CurrentPanel][8];
        }
        else _text.text = "";
    }

    public void SetNameCharacter()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 1)
        {
            _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian 
                ? GameString.gameString.names[CommonVariables.CurrentPanel].russian 
                : GameString.gameString.names[CommonVariables.CurrentPanel].english;
        }
        else _text.text = "";
    }

    public void SetPhraseCharacter()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 1)
        {
            _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian 
                ? GameString.gameString.phrase[CommonVariables.CurrentPanel].russian 
                : GameString.gameString.phrase[CommonVariables.CurrentPanel].english;
        }
        else _text.text = "";
    }

    public void SetPriceShard()
    {
        if (CommonVariables.CharacterShop[CommonVariables.CurrentPanel][7] == 0)
        {
            _text.text = (CommonVariables.GameLanguage == SystemLanguage.Russian
                             ? "Купить осколок: "
                             : "Buy shard: ") + CommonVariables.CharacterShop[CommonVariables.CurrentPanel][9];
        }
        else
        {
            if (CommonVariables.CurrentPanel == CommonVariables.EquippedSkin)
                _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian
                    ? "Экипированно"
                    : "Equipped";
            else _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian
                ? "Экипировать"
                : "Equip";
        }
    }
}
