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
    }

    void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                    DiceNumber.diceNumber = 6;
                    break;
                case "Side2":
                    DiceNumber.diceNumber = 4;
                    break;
                case "Side3":
                    DiceNumber.diceNumber = 5;
                    break;
                case "Side4":
                    DiceNumber.diceNumber = 2;
                    break;
                case "Side5":
                    DiceNumber.diceNumber = 3;
                    break;
                case "Side6":
                    DiceNumber.diceNumber = 1;
                    break;
            }
        }
    }
}
