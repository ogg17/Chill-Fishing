using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeaweedScript : MonoBehaviour
{
    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;
    [SerializeField] private float rightBoard;
    [SerializeField] private float leftBoard;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    private void Start()
    {
        UpdateWeed();
        InvokeRepeating("RepeatWeed",0.1f,0.1f);
        StartCoroutine(Initialized());
    }
    private IEnumerator Initialized()
    {
        yield return new WaitForSeconds(CommonVariables.InitializedTime);
        EventController.GameEvents.gameOver.AddListener(UpdateWeed);
    }
    public void UpdateWeed()
    {
        Vector3 pos = Vector3.zero;
        Vector3 rot = Vector3.zero;

        var rand = Random.Range(0, 2) == 0 ? pos.x = leftBoard : pos.x = rightBoard;
        pos.x += Random.Range(minOffset, maxOffset);
        pos.y = CommonVariables.DepthHook - 0.2f * Random.Range(12, 50);
        
        rot.z = Random.Range(minAngle, maxAngle);

        transform.localPosition = pos;
        transform.localEulerAngles = rot;
    }

    public void RepeatWeed()
    {
        if (transform.localPosition.y > CommonVariables.DepthHook + 3.4f)
        {
            UpdateWeed();
        }
    }
}
