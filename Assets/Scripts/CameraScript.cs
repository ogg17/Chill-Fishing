using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float speedMove;

    private Vector3 pos = Vector3.zero;

    private void Start()
    {
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
            if (transform.localPosition.y > CommonVariables.DepthHook + 1.1f) pos.y -= 3 * speedMove * Time.deltaTime;
            else pos.y -= speedMove * Time.deltaTime;
        }
        else pos.y = CommonVariables.DepthHook;
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 10 * Time.deltaTime);
        
        if(transform.localPosition.y < CommonVariables.DepthHook - 1.5f) EventController.GameEvents.gameOver.Invoke();

        if (transform.localPosition.y < -0.2f) CommonVariables.OnUnderWater = true;
        else CommonVariables.OnUnderWater = false;
    }
}
