using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField] private float stepMovement = 0.02f;
    [SerializeField] private float speedMovement = 0.05f;

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
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, CommonVariables.DepthHook), speedMovement * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish")) EventController.GameEvents.gameOver.Invoke();
    }
}
