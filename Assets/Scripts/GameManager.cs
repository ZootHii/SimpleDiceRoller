using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int diceNumber = 1;
    public GameObject dice2;
    public static GameManager instance;
    private int videoAdTrigger = 6;
    private int videoAdTriggerCount = 0;
    private float timeRemainingVideo = 300;
    private float timeRemainingBanner = 5;
    public bool isVideoAdActive = false;
    public int targetFrameRate = 90;


    private void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        instance = this;
    }


    void Update()
    {

        if (isVideoAdActive)
        {
            AdManager.instance.HideBannerAd();
            timeRemainingBanner -= Time.deltaTime;

            if (timeRemainingBanner > 0)
            {
                isVideoAdActive = false;
                timeRemainingBanner = 6;
            }
        }
        else if (!isVideoAdActive)
        {
            AdManager.instance.ShowBannerAd();
        }

        if (timeRemainingVideo > 0)
        {
            timeRemainingVideo -= Time.deltaTime;
        }
        else
        {
            AdManager.instance.ShowVideoAd();
            AdManager.instance.HideBannerAd();
            isVideoAdActive = true;
            timeRemainingVideo = 300;
        }
    }

    public void set2Dice()
    {
        if (videoAdTriggerCount == videoAdTrigger)
        {
            videoAdTriggerCount = 0;
            isVideoAdActive = true;
            AdManager.instance.ShowVideoAd();
            AdManager.instance.HideBannerAd();
        }

        videoAdTriggerCount++;

        if (diceNumber == 1)
        {
            diceNumber = 2;
            dice2.SetActive(true);
        }
        else
        {
            diceNumber = 1;
            dice2.SetActive(false);
        }
    }
}
