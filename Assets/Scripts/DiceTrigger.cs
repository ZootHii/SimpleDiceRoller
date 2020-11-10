using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    private void FixedUpdate()
    {
        Result.Dice1Result = "";
        Result.Dice2Result = "";
    }

    private void OnTriggerStay(Collider other)
    {
        switch (GameManager.DiceNumber)
        {
            case 1:
            {
                if (Dice.Instance.diceRigidBody.velocity.magnitude == Vector3.zero.magnitude && 
                    Dice.Instance.dice2RigidBody.velocity.magnitude == Vector3.zero.magnitude)
                {
                    switch (other.gameObject.name)
                    {
                        case "Dice1Side1":
                            Result.Dice1Result = "6";
                            break;
                        case "Dice1Side2":
                            Result.Dice1Result = "4";
                            break;
                        case "Dice1Side3":
                            Result.Dice1Result = "5";
                            break;
                        case "Dice1Side4":
                            Result.Dice1Result = "2";
                            break;
                        case "Dice1Side5":
                            Result.Dice1Result = "3";
                            break;
                        case "Dice1Side6":
                            Result.Dice1Result = "1";
                            break;
                        default:
                            Result.Dice1Result = "";
                            break;
                    }
                }

                break;
            }
            case 2:
            {
                if (Dice.Instance.diceRigidBody.velocity.magnitude == Vector3.zero.magnitude && 
                    Dice.Instance.dice2RigidBody.velocity.magnitude == Vector3.zero.magnitude)
                {
                    switch (other.gameObject.name)
                    {
                        case "Dice1Side1":
                            Result.Dice1Result = "6";
                            break;
                        case "Dice1Side2":
                            Result.Dice1Result = "4";
                            break;
                        case "Dice1Side3":
                            Result.Dice1Result = "5";
                            break;
                        case "Dice1Side4":
                            Result.Dice1Result = "2";
                            break;
                        case "Dice1Side5":
                            Result.Dice1Result = "3";
                            break;
                        case "Dice1Side6":
                            Result.Dice1Result = "1";
                            break;
                        case "Dice2Side1":
                            Result.Dice2Result = "6";
                            break;
                        case "Dice2Side2":
                            Result.Dice2Result = "4";
                            break;
                        case "Dice2Side3":
                            Result.Dice2Result = "5";
                            break;
                        case "Dice2Side4":
                            Result.Dice2Result = "2";
                            break;
                        case "Dice2Side5":
                            Result.Dice2Result = "3";
                            break;
                        case "Dice2Side6":
                            Result.Dice2Result = "1";
                            break;
                        default:
                            Result.Dice1Result = "";
                            Result.Dice2Result = "";
                            break;
                    }
                }
                break;
            }
        }
    }
}
