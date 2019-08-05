using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static EventController GameEvents;
    
    public UnityEvent startGame = new UnityEvent();
    public UnityEvent gameOver = new UnityEvent();
    public UnityEvent startApp = new UnityEvent();
    public UnityEvent closeApp = new UnityEvent();
}
