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
public enum EventsType
{
    GameOverExitButton,
    None
}
[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool>
{
}
public class ButtonScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private SoundType soundType = SoundType.Click;
    [SerializeField] private EventsType eventsType = EventsType.None;
    [SerializeField] private Color pressedColor; // enable image change
    [SerializeField] private bool isPressedColor; // enable pressed color
    [SerializeField] private bool playingSound; // enable playing sound

    [SerializeField] protected UnityEvent click = new UnityEvent();
    [SerializeField] protected UnityBoolEvent clickBool = new UnityBoolEvent();

    [SerializeField] private int timeInterval = 0;
    [SerializeField] private bool trigger;

    [SerializeField] private float time = 0.1f;
    [SerializeField] private float speed = 10;

    private Image imageButton;
    private Color unpressedColor;
    private bool isClick;
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

    private void Update()
    {
        if (isPressedColor && isClick) imageButton.color = Color.Lerp(imageButton.color, unpressedColor, speed * Time.deltaTime);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (DateTime.Now > clickTime + clickTimeSpan)
        {
            trigger = !trigger;
            clickTime = DateTime.Now;
            InvokeEvents();
            click.Invoke();
            clickBool.Invoke(trigger);
            if(playingSound) 
                if(soundType == SoundType.Click) SoundCenter.sounds.PlayClick();
                else if (soundType == SoundType.Coin) SoundCenter.sounds.PlayCoin();
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (isPressedColor)
        {
            imageButton.color = pressedColor;
            isClick = false;
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (isPressedColor)
        {
            isClick = true;
        }
    }

    private IEnumerator Animation()
    {
        yield return new WaitForSeconds(time/1000);
        isClick = false;
        imageButton.color = unpressedColor;
    }
    
    public void InactivateButton()
    {
        imageButton.raycastTarget = false;
    }

    public void ActivateButton()
    {
        if(imageButton != null) imageButton.raycastTarget = true;
    }
    
    public void InvokeEvents()
    {
        switch (eventsType)
        {
            case EventsType.GameOverExitButton:
                EventController.GameEvents.gameOverExitButton.Invoke();
                break;
            case EventsType.None:
                break;
            default:
                Debug.Log("This EventType is NULL!");
                break;
        }
    }
}
