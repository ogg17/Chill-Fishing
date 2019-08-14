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
    [SerializeField] private bool toggleBool;

    [SerializeField] private UnityEvent click = new UnityEvent();
    [SerializeField] private UnityBoolEvent toggle = new UnityBoolEvent();
    
    private Image _imageButton;
    private Color _unpressedColor;
    
    private void Start()
    {
        _imageButton = GetComponent<Image>();
        _unpressedColor = _imageButton.color;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        toggleBool = !toggleBool;
        click.Invoke();
        toggle.Invoke(toggleBool);
        if (changingImage) _imageButton.sprite = _imageButton.sprite == firstState ? secondState : firstState;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _imageButton.color = isPressedColor ? pressedColor : _imageButton.color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        _imageButton.color = isPressedColor ? _unpressedColor : _imageButton.color;
    }
}
