using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdMediaController : MonoBehaviour
{
    public string gameIdDroid = "3566617", placementBanner = "banner", placementVideo = "video", placementRewardedVideo = "rewardedVideo";
    public bool testMode = false; 

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
        else
        {
            Advertisement.Initialize(gameIdDroid, testMode);
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
        else
        {
            Advertisement.Initialize(gameIdDroid, testMode);
        }
    }

    public void ShowAdBanner(bool showBanner) // TODO add remove banner option
    {
        print("Advertisement is banner ready? " + Advertisement.IsReady(placementBanner));
        if (Advertisement.IsReady(placementBanner))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementBanner);
            Advertisement.Banner.Hide(showBanner); // Hide Banner
            print("Show Banner Ad");
        }
        else
        {
            Advertisement.Initialize(gameIdDroid, testMode);
        }
    }

    public IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementBanner))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementBanner);
        print("Show Banner Ad");
    }

    public void HideAdBanner()
    {
        Advertisement.Banner.Hide(false); // Hide Banner
    }

    public void ResetAdBanner()
    {
        if (Advertisement.isShowing)
        {
            Advertisement.Banner.Hide(false);
            print("Banner No Longer Showing");
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
            StartCoroutine(ShowBannerWhenReady());
            _AdCounter--;
        }
    }
}