using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

enum AdType
{
    Noun,
    CharacterMenu,
    AdGift
}
public class AdsScript : MonoBehaviour, IUnityAdsListener
{
   // public static AdsScript ads = null;
    public GiftAdScript gift;
    public string placementId = "rewardedVideo";
    private AdType adType = AdType.Noun;

    void Start () {
        /*if (ads == null)
        {
            ads = this;
        }
        else if (ads == this)
        {
            Destroy(gameObject);
        }*/
        
        if (Advertisement.isSupported) {
            Advertisement.AddListener(this);
            Advertisement.Initialize("3411348", false);
        }
    }

    public void ShowAdCharacterMenu()
    {
        adType = AdType.CharacterMenu;
        if (Advertisement.IsReady())
            Advertisement.Show(placementId);
    }

    public void ShowAdGift()
    {
        adType = AdType.AdGift;
        if (Advertisement.IsReady())
            Advertisement.Show(placementId);
    }

    public void OnUnityAdsReady(string placementId){}
    public void OnUnityAdsDidError(string message){}
    public void OnUnityAdsDidStart(string placementId){}

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && placementId == "rewardedVideo") {
            if (adType == AdType.CharacterMenu)
            {
                for (int i = 0; i < CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].ShardCount; i++)
                {
                    if (CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] == false)
                        CommonVariables.CharacterShops[CommonVariables.CurrentIndexPanel].IceShards[i] = true;
                }

                adType = AdType.Noun;
                EventController.GameEvents.updatePanel.Invoke();
            }
            else if (adType == AdType.AdGift)
            {
                gift.GiveGift();
            }
        }
    }
}
