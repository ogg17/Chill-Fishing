using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    private Text _text;

    public void SetEmptyText()
    {
        _text.text = "";
    }

    public void SetScoreText()
    {
        _text.text = CommonVariables.Score.ToString();
    }
}
