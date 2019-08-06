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

    public UnityEvent startGame = new UnityEvent();
    public UnityEvent gameOver = new UnityEvent();
    public UnityEvent startApp = new UnityEvent();
    public UnityEvent closeApp = new UnityEvent();
}
