using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ColorToggle : MonoBehaviour
{
    [SerializeField] private bool inverse = false;
    [SerializeField] private Color firstStateColor;
    [SerializeField] private Color secondStateColor;

    private Image image;
    private bool firstState = true;

    private void Start()
    {
        if (inverse) firstState = false;
        image = GetComponent<Image>();
    }
    

    public void SetStateColor()
    {
        if (firstState) {image.color = secondStateColor; firstState = false;}
        else {image.color = firstStateColor; firstState = true;}
    }

    public void SetFirstColor()
    {
        image.color = firstStateColor;
        firstState = false;
    }

    public void SetSecondColor()
    {
        image.color = secondStateColor;
        firstState = true;
    }
    
}