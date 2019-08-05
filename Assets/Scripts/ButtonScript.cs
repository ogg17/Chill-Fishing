using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Color pressedColor;
    public Sprite firstState;
    public Sprite secondState;
    public bool changingImage; // enable image change
    public bool isPressedColor; // enable pressed color
    public bool playingSound; // enable playing sound

    public UnityEvent click = new UnityEvent();

    private Image _imageButton;
    
    private void Start()
    {
        _imageButton = GetComponent<Image>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        click.Invoke();
        if (changingImage) _imageButton.sprite = _imageButton.sprite == firstState ? secondState : firstState;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _imageButton.color = isPressedColor ? pressedColor : _imageButton.color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        _imageButton.color = isPressedColor ? Color.white : _imageButton.color;
    }
}
