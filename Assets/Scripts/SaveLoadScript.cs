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
            CommonVariables.CharacterShop[i] = new int[9];
        }

        CommonVariables.CharacterShop[0][7] = 1;
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
