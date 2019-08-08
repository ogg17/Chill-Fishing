using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSprites : MonoBehaviour
{
    
    public static GameSprites gameSprites = null;

    private void Start()
    {
        if (gameSprites == null)
        {
            gameSprites = this;
        }
        else if (gameSprites == this)
        {
            Destroy(gameObject);
        }
    }
    
    public Sprite[] scrollPanelsSprite = new Sprite[CommonVariables.CharacterCount];
    public Sprite[] characterSprites = new Sprite[CommonVariables.CharacterCount];
    public Color[] backgroundCharacterColor = new Color[CommonVariables.CharacterCount];
}
