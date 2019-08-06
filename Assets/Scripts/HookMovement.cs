using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float stepMovement = 0.02f;
    public float speedMovement = 0.05f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ReloadMovement()
    {
        CommonVariables.DepthHook = 1;
    }

    public void Movement()
    {
        if (CommonVariables.GamePlaying) CommonVariables.DepthHook -= stepMovement;
    }

    private void FixedUpdate()
    {
        var position = _rigidbody2D.position;
        _rigidbody2D.position = Vector2.Lerp(position, new Vector2(position.x, CommonVariables.DepthHook), speedMovement);
    }
}
