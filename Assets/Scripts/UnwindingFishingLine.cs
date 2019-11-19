using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnwindingFishingLine : MonoBehaviour
{
    [SerializeField] private int speedMovement = 8;
    
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var position = new Vector3(0,CommonVariables.DepthHook,0);
        _lineRenderer.SetPosition(1, 
            Vector3.Lerp(_lineRenderer.GetPosition(1), position, speedMovement * Time.deltaTime));
    }
}
