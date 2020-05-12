using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdMediaController : MonoBehaviour/*, IUnityAdsListener*/
{
    public string gameIdDroid = "3566617", placementBanner = "banner", placementVideo = "video", placementRewardedVideo = "rewardedVideo";
    public bool testMode = true;

    public static AdMediaController S;
    private static int _AdCounter = 4;

    void Start()
    {
        S = this;
        Advertisement.Initialize(gameIdDroid, testMode);
    }

    public void ShowAdVideo()
    {
        print("Advertisement is video ready? " + Advertisement.IsReady(placementVideo));
        if (Advertisement.IsReady(placementVideo))
        {
            Advertisement.Show(placementVideo);
            print("Show Video Ad");
        }
    }

    public void ShowAdRewardedVideo()
    {
        print("Advertisement is video ready? " + Advertisement.IsReady(placementRewardedVideo));
        if (Advertisement.IsReady(placementRewardedVideo))
        {
            Advertisement.Show(placementRewardedVideo);
            Unlockable.UnlockThroughAd();
            print("Show Rewarded Video Ad");
        }
    }

    public void ShowAdBanner(bool showBanner) // TODO add remove banner option
    {
        print("Advertisement is banner ready? " + Advertisement.IsReady(placementBanner));
        if (Advertisement.IsReady(placementBanner))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(placementBanner);
            Advertisement.Banner.Hide(showBanner); // Hide Banner
            print("Show Banner Ad");
        }
    }

    public void AdCounter()
    {
        if (_AdCounter <= 0)
        {
            ShowAdVideo();
            _AdCounter = 4;
        }
        else if (_AdCounter > 3)
        {
            _AdCounter--;
        }
        else
        {
            ShowAdBanner(true);
            _AdCounter--;
        }
        print("Ad counter = " + _AdCounter);
    }

    /*
    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            Unlockable.UnlockThroughAd();
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
    */
}
