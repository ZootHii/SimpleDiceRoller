using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private static readonly string playStoreID = "3856609";

    private static readonly string videoAd = "video";
    private static readonly string bannerAd = "banner";

    private static bool testMode = true;

    private void Awake()
    {
        instance = this;
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        Advertisement.Initialize(playStoreID, testMode);
    }

    public void ShowVideoAd()
    {
        if (Advertisement.IsReady(videoAd))
        {
            Advertisement.Show(videoAd);
        }
    }

    public void ShowBannerAd()
    {
        instance.StartCoroutine(ShowBannerWhenReady());
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private static IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerAd))
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAd);
    }
}
