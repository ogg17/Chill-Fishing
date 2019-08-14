using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIScript : MonoBehaviour
{
    [SerializeField] private Vector2 firstState;
    [SerializeField] private Vector2 secondState;
    
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ChangeImageState()
    {
        _rectTransform.sizeDelta = _rectTransform.sizeDelta == firstState ? secondState : firstState;
    }
}
