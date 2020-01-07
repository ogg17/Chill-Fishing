using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static EventController GameEvents = null;

    private void Start()
    {
        if (GameEvents == null)
        {
            GameEvents = this;
        }
        else if (GameEvents == this)
        {
            Destroy(gameObject);
        }
    }

    public UnityEvent stepGame = new UnityEvent();
    public UnityEvent startGame = new UnityEvent();
    public UnityEvent gameOver = new UnityEvent();
    public UnityEvent startApp = new UnityEvent();
    public UnityEvent firstStartApp = new UnityEvent();
    public UnityEvent pickUpCoin = new UnityEvent();
    public UnityEvent updatePanel = new UnityEvent();
    public UnityEvent goldFishBonus = new UnityEvent();
    public UnityEvent partFishBonus = new UnityEvent();
    public UnityEvent setLanguage = new UnityEvent();
}
