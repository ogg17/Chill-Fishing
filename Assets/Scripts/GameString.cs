using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameString : MonoBehaviour
{
    public static GameString gameString = null;

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
    }
    
    public StringLang[] names = new StringLang[CommonVariables.CharacterCount];
    public StringLang[] phrase = new StringLang[CommonVariables.CharacterCount];
    public StringLang[] packs = new StringLang[CommonVariables.PacksCount];
}

[System.Serializable]
public class StringLang
{
    public String russian;
    public String english;
}
