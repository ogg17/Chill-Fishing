using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMotion : MonoBehaviour
{
    bool EnabledWindow = false;
    public Vector2 startValue;
    public Vector2 endValue;
    public float speed = 0.2f;
    Vector3 velosity = Vector3.zero;
    Vector3 moveValue;
    private void Start()
    {
        moveValue = transform.localPosition;
    }
    public void MoveWindow()
    {
        if (!EnabledWindow) { moveValue.x = endValue.x; moveValue.y = endValue.y; EnabledWindow = true; }
        else { moveValue.x = startValue.x; moveValue.y = startValue.y; EnabledWindow = false; }
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, moveValue, ref velosity, speed);
    }
}
