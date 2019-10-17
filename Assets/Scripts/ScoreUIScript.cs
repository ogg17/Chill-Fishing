using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIScript : MonoBehaviour
{
    [SerializeField] private Vector2 firstState;
    [SerializeField] private Vector2 secondState;
    
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void ChangeImageStateFirst()
    {
        rectTransform.sizeDelta = firstState;
    }

    public void ChangeImageStateSecond() => rectTransform.sizeDelta = secondState;
}
