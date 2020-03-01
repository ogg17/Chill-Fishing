using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuMotion : MonoBehaviour
{
    [SerializeField] private bool inverse = false;
    [SerializeField] private Vector2 startValue;
    [SerializeField] private Vector2 endValue;
    [SerializeField] private float speed = 0.2f;
    private Vector3 moveValue;
    private bool firstState = true;
    private void Start()
    {
        if (inverse) firstState = false;
        moveValue = transform.localPosition;
    }
    public void MoveWindow()
    {
        if (firstState) { moveValue.x = endValue.x; moveValue.y = endValue.y; firstState = false; }
        else { moveValue.x = startValue.x; moveValue.y = startValue.y; firstState = true; }
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, moveValue, speed);
    }
}
