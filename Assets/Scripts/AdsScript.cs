using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdsScript : MonoBehaviour
{
    public string placementId = "rewardedVideo";

    void Start () {
        if (Monetization.isSupported) {
            Monetization.Initialize("3409168", false);
        }
    }

    void ShowAd () {
        ShowAdCallbacks options = new ShowAdCallbacks ();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;
        ad.Show (options);
    }

    void HandleShowResult (ShowResult result) {
        if (result == ShowResult.Finished) {
            for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
            {
                if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == false) 
                    CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] = true;
            }
            EventController.GameEvents.updatePanel.Invoke();
        } else if (result == ShowResult.Skipped) {
            Debug.LogWarning ("The player skipped the video - DO NOT REWARD!");
        } else if (result == ShowResult.Failed) {
            Debug.LogError ("Video failed to show");
        }
    }
}
