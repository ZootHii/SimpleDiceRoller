using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int diceNumber = 1;
    public GameObject dice2;
    public static GameManager instance;
    private static int videoAdTrigger = 6;
    private static int videoAdTriggerCount = 0;
    private float timeRemainingVideo = 300;
    private float timeRemainingBanner = 5;
    private bool isVideoAdActive = false;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        /*if (isVideoAdActive)
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
        else
        {
            Debug.Log("Show Video Ad");
            AdManager.ShowVideoAd();
            AdManager.HideBannerAd();
            isVideoAdActive = true;
            timeRemainingVideo = 300;
        }*/

    }

    public void set2Dice()
    {
        
        /*AdManager.HideBannerAd();*/

        Debug.Log(videoAdTrigger);
        Debug.Log(videoAdTriggerCount);
       
        if (videoAdTriggerCount == videoAdTrigger)
        {
            videoAdTriggerCount = 0;
            isVideoAdActive = true;
            AdManager.instance.ShowVideoAd();
            /*AdManager.HideBannerAd();*/
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
