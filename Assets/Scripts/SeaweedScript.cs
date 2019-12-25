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
    
    private static List<(float, float)> otherRands = new List<(float, float)>();
    private static int globalIndx = 0;
    private int indx = 0;

    private void Start()
    {
        indx = globalIndx;
        globalIndx++;
        otherRands.Add((0f, 0f));
        
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

        var rand = Random.Range(0, 2);
        //var minRand = Random.Range(minOffset, maxOffset);
        if (rand == 0)
        {
            pos.x = leftBoard;
            rot.z = Random.Range(minAngle, 0);
        }
        else
        {
            pos.x = rightBoard;
            rot.z = Random.Range(0, maxAngle);
        }

        int randY = Random.Range(12, 50);
        bool done = true;
        int iter = 0;
        while (done)
        {
            iter++;
            bool chek = false;
            foreach (var n in otherRands)
            {
                if (n.Item2 == rand && n.Item1 == randY) 
                {
                    randY = Random.Range(12, 30);
                    chek = true;
                }
            }
            if (chek == false) done = false;
            if(iter > 1000) break;
        }

        otherRands[indx] = (randY, rand);
        pos.y = CommonVariables.DepthHook - 0.2f * randY;

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
