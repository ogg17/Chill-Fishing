using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToggle : MonoBehaviour
{
    [SerializeField] private bool inverse = false;
    [SerializeField] private TranslateString firsPhrase;
    [SerializeField] private TranslateString secondPhrase;
    [SerializeField] private Color firstColor;
    [SerializeField] private Color secondColor;
    private Text text;
    private bool firstState = true;

    private void Start()
    {
        text = GetComponent<Text>();
        if (inverse) firstState = false;
    }

    public void SetStateText()
    {
        if (firstState)
        {
            text.color = secondColor;
            text.text = secondPhrase;
            firstState = false;
        }
        else
        {
            text.color = firstColor;
            text.text = firsPhrase;
            firstState = true;
        }
    }
}
