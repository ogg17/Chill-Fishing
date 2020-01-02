using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField] private float stepMovement = 0.02f;
    [SerializeField] private float speedMovement = 0.05f;
    
    private Vector2 pos = Vector2.zero;

    private void Start()
    {
        pos.x = transform.position.x;
    }

    public void ReloadMovement()
    {
        CommonVariables.DepthHook = 1;
    }

    public void Movement()
    {
        if (CommonVariables.GamePlaying) CommonVariables.DepthHook -= stepMovement;
    }

    private void Update()
    {
        pos.y = CommonVariables.DepthHook;
        transform.position = Vector2.Lerp(transform.position, pos, speedMovement * Time.deltaTime);
    }
}
