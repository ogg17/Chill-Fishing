using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{

    [SerializeField] private Sprite firstStateImage;
    [SerializeField] private Sprite secondStateImage;
    [SerializeField] private Color offsetColor;

    private Image image;
    private bool firstState;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void SetColorBackgroundCharacter()
    {
        if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].BuyCharacter == true)
            image.color = GameSprites.gameSprites.characterSprites[CommonVariables.CurrentIndexPanel].
                characterBackgroundShopColor - offsetColor;
        else image.color = Color.gray - offsetColor;
    }

    public void SetStateImage()
    {
        if (firstState) {image.sprite = secondStateImage; firstState = false;}
        else {image.sprite = firstStateImage; firstState = true;}
    }

    public void SetFirstState()
    {
        image.sprite = firstStateImage;
        firstState = false;
    }

    public void SetSecondState()
    {
        image.sprite = secondStateImage;
        firstState = true;
    }
    
}
