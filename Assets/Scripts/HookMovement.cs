using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField] private float stepMovement = 0.02f;
    [SerializeField] private float speedMovement = 0.05f;

    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        var position = rigidbody2d.position;
        rigidbody2d.position = Vector2.Lerp(position, new Vector2(position.x, CommonVariables.DepthHook), speedMovement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish")) EventController.GameEvents.gameOver.Invoke();
    }
}
