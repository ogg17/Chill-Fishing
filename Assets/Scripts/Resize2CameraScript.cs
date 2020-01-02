using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize2CameraScript : MonoBehaviour
{
    [SerializeField] private float koof = 1f;
    void Start()
    {
        Vector3 cameraSize = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0))
                  - Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        transform.localScale = new Vector3(Mathf.Abs(cameraSize.x)*koof, Mathf.Abs(cameraSize.y)*koof, 1);
    }
}
