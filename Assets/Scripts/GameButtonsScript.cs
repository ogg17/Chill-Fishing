using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameButtonsScript : ButtonScript, IPointerClickHandler
{
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId < 1 && DateTime.Now > clickTime + clickTimeSpan)
        {
            clickTime = DateTime.Now;
            click.Invoke();
        }
    }
}
