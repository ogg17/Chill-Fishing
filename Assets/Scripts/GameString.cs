using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
using File = UnityEngine.Windows.File;

public class GameString : MonoBehaviour
{
    public static GameString gameString = null;

    [SerializeField] private TextAsset fileJson;
    public StringPacks stringPacks; 
    
    // UI Strings ---------------------------------
    public TranslateString uiGold;
    public TranslateString uiScore;

    // Button Strings -----------------------------
    public TranslateString bCharacterSmash;
    public TranslateString bCharacterEquip;
    public TranslateString bCharacterEquipped;
    public TranslateString bCharacterBuy;
    public TranslateString bExit;
    
    private void Start()
    {
        if (gameString == null)
        {
            gameString = this;
        }
        else if (gameString == this)
        {
            Destroy(gameObject);
        }
        
        stringPacks = JsonUtility.FromJson<StringPacks>(fileJson.text);
    }

}

[System.Serializable]
public class StringPacks
{
    public StringPack[] packs = new StringPack[10];
}
[System.Serializable]
public class StringPack
{
    public TranslateString packName;
    public Character[] characters = new Character[3];
}
[System.Serializable]
public class Character
{
    public TranslateString name;
    public TranslateString characteristic;
    public TranslateString[] phrase = new TranslateString[3];
}

