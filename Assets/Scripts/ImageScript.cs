using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    public void SetColorBackgroundCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentPanel].BuyCharacter == true)
            _image.color = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentPanel].characterBackgroundShopColor;
        else _image.color = Color.gray;
    }
    
}
