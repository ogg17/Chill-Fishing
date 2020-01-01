using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float speedMove;

    private Camera camera;
    private Vector3 pos = Vector3.zero;

    private void Start()
    {
        camera = GetComponent<Camera>();
        float x = camera.aspect;
        CommonVariables.CameraSize = (float)Math.Round(4.2712f*x*x-7.2072f*x + 4.2026f, 2);
        camera.orthographicSize = CommonVariables.CameraSize;
        StartCoroutine(Initialized());
        pos.y = CommonVariables.DepthHook;
        pos.z = transform.localPosition.z;
    }

    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(ReloadCamera);
    }

    public void ReloadCamera()
    {
        pos.y = CommonVariables.DepthHook;
    }
    private void Update()
    {
        if (CommonVariables.GamePlaying)
        {
            if (transform.localPosition.y > CommonVariables.DepthHook + CommonVariables.CameraSize - 0.4f) pos.y -= 3 * speedMove * Time.deltaTime;
            else pos.y -= speedMove * Time.deltaTime;
        }
        else pos.y = CommonVariables.DepthHook;
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 10 * Time.deltaTime);
        
        if(transform.localPosition.y < CommonVariables.DepthHook - CommonVariables.CameraSize) EventController.GameEvents.gameOver.Invoke();

        if (transform.localPosition.y < -0.2f) CommonVariables.OnUnderWater = true;
        else CommonVariables.OnUnderWater = false;
    }
}
