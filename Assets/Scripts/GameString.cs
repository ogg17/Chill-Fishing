using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    public StringPack[] stringPacksRus = new StringPack[10];
    public StringPack[] stringPacksEng = new StringPack[10];
}

[System.Serializable]
public class StringPack
{
    public string packName;
    public Character[] characters = new Character[3];
}
[System.Serializable]
public class Character
{
    public string name;
    public string characteristic;
    public string[] phrase = new string[3];
}
