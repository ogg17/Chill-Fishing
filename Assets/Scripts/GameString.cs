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
    
    public String[] names = new string[CommonVariables.CharacterCount];
}
