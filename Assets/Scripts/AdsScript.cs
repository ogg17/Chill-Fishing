using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsScript : MonoBehaviour, IUnityAdsListener
{
    public string placementId = "rewardedVideo";

    void Start () {
        if (Advertisement.isSupported) {
            Advertisement.AddListener(this);
            Advertisement.Initialize("3409168", false);
        }
    }

    void ShowAd () {
        if (Advertisement.IsReady())
            Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsReady(string placementId){}
    public void OnUnityAdsDidError(string message){}
    public void OnUnityAdsDidStart(string placementId){}

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && placementId == "rewardedVideo") {
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == false) 
                    CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] = true;
            }
            EventController.GameEvents.updatePanel.Invoke();
        }
    }
}
