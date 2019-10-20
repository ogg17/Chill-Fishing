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
    [SerializeField] private Color pressedColor; // enable image change
    [SerializeField] private bool isPressedColor; // enable pressed color
    [SerializeField] private bool playingSound; // enable playing sound

    [SerializeField] private UnityEvent click = new UnityEvent();
    [SerializeField] private UnityEvent down = new UnityEvent();
    [SerializeField] private UnityEvent up = new UnityEvent();

    private Image imageButton;
    private Color unpressedColor;
    
    private void Start()
    {
        imageButton = GetComponent<Image>();
        unpressedColor = imageButton.color;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        click.Invoke();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        down.Invoke();
        imageButton.color = isPressedColor ? pressedColor : imageButton.color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        up.Invoke();
        imageButton.color = isPressedColor ? unpressedColor : imageButton.color;
    }
}
