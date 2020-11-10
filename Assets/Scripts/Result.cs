using System;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public static string Dice1Result;
    public static string Dice2Result;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if (Time.frameCount % 7 == 0)
        {
            switch (GameManager.DiceNumber)
            {
                case 1:
                {
                    if (Dice1Result == "")
                    {
                        textMeshPro.text = "";
                    }

                    textMeshPro.text = Dice1Result;
                    break;
                }
                case 2 when Dice1Result == "" && Dice2Result == "":
                case 2 when Dice1Result == "" || Dice2Result == "":
                    textMeshPro.text = "";
                    break;
                case 2:
                {
                    var result1 = int.Parse(Dice1Result);
                    var result2 = int.Parse(Dice2Result);
                    var result = result1 + result2;
                    textMeshPro.text = result.ToString();
                    break;
                }
            }
        }
    }
}
