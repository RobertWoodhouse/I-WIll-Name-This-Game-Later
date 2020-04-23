using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdMediaController : MonoBehaviour
{
    public string gameIdDroid = "3566617", placementIdBanner = "banner", placementIdVideo = "banner";
    public bool testMode = true;

    public static AdMediaController S;

    void Start()
    {
        S = this;
        Advertisement.Initialize(gameIdDroid, testMode);
    }

    public void ShowAdVideo()
    {
        print("Advertisement is video ready? " + Advertisement.IsReady(placementIdVideo));
        if (Advertisement.IsReady(placementIdVideo))
        {
            Advertisement.Show(placementIdVideo);
            print("Show Video Ad");
        }
    }

    public void ShowAdBanner()
    {
        print("Advertisement is banner ready? " + Advertisement.IsReady(placementIdBanner));
        if (Advertisement.IsReady(placementIdBanner))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(placementIdBanner);
            print("Show Banner Ad");
        }
    }
}
