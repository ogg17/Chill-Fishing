using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    [SerializeField] private Sprite firstStateImage;
    [SerializeField] private Sprite secondStateImage;
    [SerializeField] private Color offsetColor;

    private SpriteRenderer image;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }
    
    public void SetStateImage()
    {
        if (image.sprite == firstStateImage) image.sprite = secondStateImage;
        else image.sprite = firstStateImage;
    }
}
