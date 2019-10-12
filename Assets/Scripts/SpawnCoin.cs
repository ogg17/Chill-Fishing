using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private int stepProbably = 2;
    [SerializeField] private float depthCoin;
    [SerializeField] private GameObject coin;
    
    private int probably = 0;
    
    public void SpawningCoin()
    {
        if (CommonVariables.GamePlaying)
        {
            if (Random.Range(1, 101) <= + probably)
            {
                var copyCoin = Instantiate(coin, new Vector3(0, CommonVariables.DepthHook - depthCoin, 0),
                    transform.rotation);
                probably = 0;
            }
            else probably += stepProbably;
        }
    }
}
