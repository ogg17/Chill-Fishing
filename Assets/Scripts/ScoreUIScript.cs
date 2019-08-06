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
        _spriteRenderer.sprite = _spriteRenderer.sprite == firstState ? secondState : firstState;
    }
}
