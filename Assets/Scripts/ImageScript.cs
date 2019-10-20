using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{

    [SerializeField] private Sprite firstStateImage;
    [SerializeField] private Sprite secondStateImage;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetColorBackgroundCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
            image.color = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel].characterBackgroundShopColor;
        else image.color = Color.gray;
    }

    public void SetStateImage()
    {
        if (image.sprite == firstStateImage) image.sprite = secondStateImage;
        else image.sprite = firstStateImage;
    }
    
}
