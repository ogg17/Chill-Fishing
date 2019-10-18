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
    public CharacterSprites[] characterSprites = new CharacterSprites[CommonVariables.CharacterCount];
}

[System.Serializable]
public class CharacterSprites
{
    public Sprite scrollPanelSprite;
    public Sprite characterShopSprite;
    public Sprite characterGameSprite;
    public Sprite characterFormSprite;
    public Color characterBackgroundShopColor;
    public Sprite[] icePieceSprites = new Sprite[3];
}

[System.Serializable]
public class PacksSprites
{
    public CharacterSprites[] characters = new CharacterSprites[3];
}
