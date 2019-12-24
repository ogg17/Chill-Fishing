using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    [SerializeField] private Sprite firstStateImage;
    [SerializeField] private Sprite secondStateImage;
   // [SerializeField] private Color offsetColor;

    private SpriteRenderer image;
    private bool firstState;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
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
