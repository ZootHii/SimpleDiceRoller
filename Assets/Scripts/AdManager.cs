using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private static AdManager instance;

    private const string PlayStoreId = "YOUR ID";

    private const string VideoAd = "video";
    private const string BannerAd = "banner";

    private const bool TestMode = true;

    private void Awake()
    {
        instance = this;
        InitializeAdvertisement();
    }

    private static void InitializeAdvertisement()
    {
        Advertisement.Initialize(PlayStoreId, TestMode);
    }

    public static void ShowVideoAd()
    {
        if (Advertisement.IsReady(VideoAd))
        {
            Advertisement.Show(VideoAd);
        }
    }

    public static void ShowBannerAd()
    {
        instance.StartCoroutine(ShowBannerWhenReady());
    }

    public static void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private static IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(BannerAd))
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(BannerAd);
    }
}
