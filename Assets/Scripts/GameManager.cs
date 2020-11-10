using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int DiceNumber = 1;
    public GameObject dice2;
    public static GameManager Instance;
    private const int VideoAdTrigger = 6;
    private int videoAdTriggerCount;
    private float timeRemainingVideo = 120;
    private float timeRemainingBanner = 5;
    public bool isVideoAdActive;
    public int targetFrameRate = 60;


    private void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        Instance = this;
    }
    
    private void FixedUpdate()
    {
        AdStuff();
    }

    private void AdStuff()
    {
        if (isVideoAdActive)
        {
            AdManager.HideBannerAd();
            timeRemainingBanner -= Time.deltaTime;

            if (timeRemainingBanner > 0)
            {
                isVideoAdActive = false;
                timeRemainingBanner = 6;
            }
        }
        else if (!isVideoAdActive)
        {
            AdManager.ShowBannerAd();
        }

        if (timeRemainingVideo > 0)
        {
            timeRemainingVideo -= Time.deltaTime;
        }
        else if(!isVideoAdActive)
        {
            AdManager.ShowVideoAd();
            AdManager.HideBannerAd();
            isVideoAdActive = true;
            timeRemainingVideo = 120;
        }
    }
    
    public void Set2Dice()
    {
        if (videoAdTriggerCount == VideoAdTrigger && !isVideoAdActive)
        {
            videoAdTriggerCount = 0;
            isVideoAdActive = true;
            AdManager.ShowVideoAd();
            AdManager.HideBannerAd();
        }

        videoAdTriggerCount++;

        switch (DiceNumber)
        {
            case 1:
                DiceNumber = 2;
                dice2.SetActive(true);
                break;
            case 2:
                DiceNumber = 1;
                dice2.SetActive(false);
                break;
        }
    }
}
