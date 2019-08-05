using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnwindingFishingLine : MonoBehaviour
{
    public float speedUnwinding;
    public Transform hookPosition;
    
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        var position = new Vector3(0,hookPosition.position.y,0);
        _lineRenderer.SetPosition(1, position);
    }
}
