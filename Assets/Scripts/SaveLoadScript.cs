using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{
    private void Awake()
    {
        for (var i = 0; i < CommonVariables.PacksCount; i++)
        {
            for (var j = 0; j < CommonVariables.CharacterPacks[i]; j++)
            {
                CommonVariables.CharacterShops.Add(new CharacterShop());
            }
        }

        CommonVariables.CharacterShops[0].BuyCharacter = true;
        CommonVariables.CharacterShops[8].ShardCount = 3;
        CommonVariables.CharacterShops[9].ShardCount = 3;

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
