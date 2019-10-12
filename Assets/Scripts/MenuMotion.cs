using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuMotion : MonoBehaviour
{
    [SerializeField] private bool enabledWindow = false;
    [SerializeField] private Vector2 startValue;
    [SerializeField] private Vector2 endValue;
    [SerializeField] private float speed = 0.2f;
    private Vector3 moveValue;
    private void Start()
    {
        moveValue = transform.localPosition;
    }
    public void MoveWindow()
    {
        if (!enabledWindow) { moveValue.x = endValue.x; moveValue.y = endValue.y; enabledWindow = true; }
        else { moveValue.x = startValue.x; moveValue.y = startValue.y; enabledWindow = false; }
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, moveValue, speed);
    }
}
