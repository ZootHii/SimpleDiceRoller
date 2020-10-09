using UnityEngine;

public class DiceTrigger : MonoBehaviour
{

    Vector3 diceVelocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Dice.instance.diceVelocity != null)
        {
            diceVelocity = Dice.instance.diceVelocity;
        }
        Result.dice1Result = "";
        Result.dice2Result = "";
    }

    void OnTriggerStay(Collider col)
    {

        if (GameManager.instance.diceNumber == 1)
        {
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name)
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
                }
            }
        }
        else if (GameManager.instance.diceNumber == 2)
        {
            if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
            {
                switch (col.gameObject.name)
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
                }
            }
        }

    }
}
