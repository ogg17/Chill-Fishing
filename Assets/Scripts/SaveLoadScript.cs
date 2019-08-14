using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
    private void Awake()
    {
        for (var i = 0; i < CommonVariables.CharacterCount; i++)
        {
            CommonVariables.CharacterShop[i] = new int[11];
            CommonVariables.CharacterShop[i][8] = 5;
            CommonVariables.CharacterShop[i][9] = 30;
        }

        CommonVariables.CharacterShop[0][7] = 1;
        CommonVariables.CharacterShop[8][8] = 3;
        CommonVariables.CharacterShop[9][8] = 3;

        //CommonVariables.GameLanguage = Application.systemLanguage == SystemLanguage.Russian 
         //   ? SystemLanguage.Russian : SystemLanguage.English;
    }
    private void Save()
    {
        
    }
    private void OnApplicationQuit() => Save();

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Save();
    }
}
