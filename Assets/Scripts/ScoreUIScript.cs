using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIScript : MonoBehaviour
{
    public Sprite firstState;
    public Sprite secondState;
    
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeImageState()
    {
        if (_spriteRenderer.sprite == firstState) _spriteRenderer.sprite = secondState;
        else _spriteRenderer.sprite = firstState;
    }
}
