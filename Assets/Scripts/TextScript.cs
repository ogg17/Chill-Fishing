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
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == true) count++;
            }
            _text.text = count + "/" + CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount;
        }
        else _text.text = "";
    }

    public void SetNameCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
        {
            _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian 
                ? GameString.gameString.names[CommonVariables.CurrentIndexPanel].russian 
                : GameString.gameString.names[CommonVariables.CurrentIndexPanel].english;
        }
        else _text.text = "???";
    }

    public void SetPhraseCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
        {
            _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian 
                ? GameString.gameString.phrase[CommonVariables.CurrentIndexPanel].russian 
                : GameString.gameString.phrase[CommonVariables.CurrentIndexPanel].english;
        }
        else _text.text = "";
    }

    public void SetPriceShard()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            int count = 0;
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == true) count++;
            }

            if (count == CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount)
            {
                _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian
                    ? "Разбить"
                    : "Smash";
            }
            else
                _text.text = (CommonVariables.GameLanguage == SystemLanguage.Russian
                     ? "Купить осколок: "
                     : "Buy shard: ") + CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardPrice;
        }
        else
        {
            if (CommonVariables.CurrentIndexPanel == CommonVariables.EquippedSkin)
                _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian
                    ? "Экипированно"
                    : "Equipped";
            else _text.text = CommonVariables.GameLanguage == SystemLanguage.Russian
                ? "Экипировать"
                : "Equip";
        }
    }
}
