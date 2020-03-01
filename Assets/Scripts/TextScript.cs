using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using ComVar = CommonVariables;

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
        if (CommonVariables.GamePlaying) _text.text = CommonVariables.Score + "m";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    }
    public void SetGoldText()
    {
        _text.text = CommonVariables.Gold + "G";
    }

    public void SetIceShardCount()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == false)
        {
            int count = 0;
            for (int i = 0; i < ComVar.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
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
            _text.text = GameString.gameString.stringPacks.packs[CommonVariables.CurrentPack].
                characters[CommonVariables.CurrentPanel].name;
        }
        else _text.text = "???";
    }

    public void SetPhraseCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
        {
            bool check = true;
           // while (check)
            {
                string newPhrase = GameString.gameString.stringPacks.packs[CommonVariables.CurrentPack]
                    .characters[CommonVariables.CurrentPanel].phrase[UnityEngine.Random.
                        Range(0, GameString.gameString.stringPacks.packs[CommonVariables.CurrentPack]
                            .characters[CommonVariables.CurrentPanel].phrase.Length)];
                if ("\""+ newPhrase + "\"" != _text.text){
                    _text.text = "\"" + newPhrase + "\"";
                    check = false;
                }
            }
        }
        else _text.text = "";
    }

    public void SetCharacteristicCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
        {
            _text.text = GameString.gameString.stringPacks.packs[CommonVariables.CurrentPack]
                .characters[CommonVariables.CurrentPanel].characteristic;
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
                _text.text = GameString.gameString.bCharacterSmash;
            }
            else
                _text.text = GameString.gameString.bCharacterBuy + " " + 
                             CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardPrice + "G";
        }
        else
        {
            if (CommonVariables.CurrentIndexPanel == CommonVariables.EquippedSkin)
                _text.text = GameString.gameString.bCharacterEquipped;
            else
                _text.text = GameString.gameString.bCharacterEquip;
        }
    }

    public void SetLanguageText()
    {
        _text.text = GameString.gameString.bLanguage;
    }

    public void SetEndGold()
    {
        if (_text != null)
            _text.text = GameString.gameString.uiEndGold + CommonVariables.GoldSession;
        else StartCoroutine(setEndGold());
    }

    public IEnumerator setEndGold()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        _text.text = _text.text = GameString.gameString.uiEndGold + CommonVariables.GoldSession;
    }
    
    public void SetEndRecord()
    {
        if (_text != null)
            _text.text = GameString.gameString.uiEndRecord + CommonVariables.Record;
        else StartCoroutine(setEndRecord());
    }

    public IEnumerator setEndRecord()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        _text.text = GameString.gameString.uiEndRecord + CommonVariables.Record;
    }
    
    public void SetEndScore()
    {
        if (_text != null)
            _text.text = GameString.gameString.uiEndScore + CommonVariables.Score;
        else StartCoroutine(setEndScore());
    }

    public IEnumerator setEndScore()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        _text.text = GameString.gameString.uiEndScore + CommonVariables.Score;
    }
}
