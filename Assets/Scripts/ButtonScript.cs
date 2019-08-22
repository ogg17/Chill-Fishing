using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool>
{
}
public class ButtonScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color pressedColor;
    [SerializeField] private Sprite firstState;
    [SerializeField] private Sprite secondState;
    [SerializeField] private bool changingImage; // enable image change
    [SerializeField] private bool isPressedColor; // enable pressed color
    [SerializeField] private bool playingSound; // enable playing sound

    [SerializeField] private UnityEvent click = new UnityEvent();
    [SerializeField] private UnityEvent down = new UnityEvent();
    [SerializeField] private UnityEvent up = new UnityEvent();

    private Image _imageButton;
    private Color _unpressedColor;
    
    private void Start()
    {
        _imageButton = GetComponent<Image>();
        _unpressedColor = _imageButton.color;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        click.Invoke();
        if (changingImage) _imageButton.sprite = _imageButton.sprite == firstState ? secondState : firstState;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        down.Invoke();
        _imageButton.color = isPressedColor ? pressedColor : _imageButton.color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        up.Invoke();
        _imageButton.color = isPressedColor ? _unpressedColor : _imageButton.color;
    }
}
