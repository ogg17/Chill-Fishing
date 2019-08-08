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

    public void SetCharacter()
    {
        _image.sprite = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentPanel];
    }

    public void SetColorBackgroundCharacter()
    {
        _image.color = GameSprites.gameSprites.backgroundCharacterColor[CommonVariables.CurrentPanel];
    }
    
}
