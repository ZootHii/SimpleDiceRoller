using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    private int videoAdTriggerFor1Dice = 15;
    private int videoAdTriggerFor2Dice = 30;
    private int videoAdTriggerCount = 0;

    void FixedUpdate()
    {

        Result.dice1Result = "";
        Result.dice2Result = "";
    }

    void OnTriggerStay(Collider collider)
    {
        if (GameManager.instance.diceNumber == 1)
        {
            if (Dice.instance.diceRigidBody.velocity == Vector3.zero)
            {
                switch (collider.gameObject.name)
                {
                    case "Dice1Side1":
                        Result.dice1Result = "6";
                        break;
                    case "Dice1Side2":
                        Result.dice1Result = "4";
                        break;
                    case "Dice1Side3":
                        Result.dice1Result = "5";
                        break;
                    case "Dice1Side4":
                        Result.dice1Result = "2";
                        break;
                    case "Dice1Side5":
                        Result.dice1Result = "3";
                        break;
                    case "Dice1Side6":
                        Result.dice1Result = "1";
                        break;
                    default:
                        Result.dice1Result = "";
                        break;
                }
            }
        }
        else if (GameManager.instance.diceNumber == 2)
        {
            if (Dice.instance.diceRigidBody.velocity == Vector3.zero)
            {
                switch (collider.gameObject.name)
                {
                    case "Dice1Side1":
                        Result.dice1Result = "6";
                        break;
                    case "Dice1Side2":
                        Result.dice1Result = "4";
                        break;
                    case "Dice1Side3":
                        Result.dice1Result = "5";
                        break;
                    case "Dice1Side4":
                        Result.dice1Result = "2";
                        break;
                    case "Dice1Side5":
                        Result.dice1Result = "3";
                        break;
                    case "Dice1Side6":
                        Result.dice1Result = "1";
                        break;
                    case "Dice2Side1":
                        Result.dice2Result = "6";
                        break;
                    case "Dice2Side2":
                        Result.dice2Result = "4";
                        break;
                    case "Dice2Side3":
                        Result.dice2Result = "5";
                        break;
                    case "Dice2Side4":
                        Result.dice2Result = "2";
                        break;
                    case "Dice2Side5":
                        Result.dice2Result = "3";
                        break;
                    case "Dice2Side6":
                        Result.dice2Result = "1";
                        break;
                    default:
                        Result.dice1Result = "";
                        Result.dice2Result = "";
                        break;
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (GameManager.instance.diceNumber == 1)
        {
            if (Dice.instance.diceRigidBody.velocity == Vector3.zero)
            {
                if (videoAdTriggerCount == videoAdTriggerFor1Dice)
                {
                    videoAdTriggerCount = 0;
                    GameManager.instance.isVideoAdActive = true;
                    AdManager.instance.HideBannerAd();
                    AdManager.instance.ShowVideoAd();
                }

                videoAdTriggerCount++;
            }
        }

        else if (GameManager.instance.diceNumber == 2)
        {
            if (Dice.instance.diceRigidBody.velocity == Vector3.zero)
            {
                if (videoAdTriggerCount == videoAdTriggerFor2Dice)
                {
                    videoAdTriggerCount = 0;
                    GameManager.instance.isVideoAdActive = true;
                    AdManager.instance.HideBannerAd();
                    AdManager.instance.ShowVideoAd();
                }
                videoAdTriggerCount++;
            }
        }
    }
}
