using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

enum SoundType
{
    Click,
    Coin
}

[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool>
{
}
public class ButtonScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private SoundType soundType = SoundType.Click;
    [SerializeField] private Color pressedColor; // enable image change
    [SerializeField] private bool isPressedColor; // enable pressed color
    [SerializeField] private bool playingSound; // enable playing sound

    [SerializeField] protected UnityEvent click = new UnityEvent();
    [SerializeField] protected UnityBoolEvent clickBool = new UnityBoolEvent();

    [SerializeField] private int timeInterval = 0;
    [SerializeField] private bool trigger;

    private Image imageButton;
    private Color unpressedColor;
    protected DateTime clickTime;
    
    protected TimeSpan clickTimeSpan = TimeSpan.Zero;
    private void Start()
    {
        imageButton = GetComponent<Image>();
        unpressedColor = imageButton.color;
        clickTimeSpan = new TimeSpan(0,0,0,0,timeInterval);
        clickTime = DateTime.Now;
       // StartCoroutine(Initialized());
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (DateTime.Now > clickTime + clickTimeSpan)
        {
            trigger = !trigger;
            clickTime = DateTime.Now;
            click.Invoke();
            clickBool.Invoke(trigger);
            if(playingSound) 
                if(soundType == SoundType.Click) SoundCenter.sounds.PlayClick();
                else if (soundType == SoundType.Coin) SoundCenter.sounds.PlayCoin();
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        imageButton.color = isPressedColor ? pressedColor : imageButton.color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        imageButton.color = isPressedColor ? unpressedColor : imageButton.color;
    }

    public void InactivateButton()
    {
        imageButton.raycastTarget = false;
    }

    public void ActivateButton()
    {
        if(imageButton != null) imageButton.raycastTarget = true;
    }
}
