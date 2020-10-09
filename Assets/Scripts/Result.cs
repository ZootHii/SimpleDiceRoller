using System;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{

    TextMeshPro textMeshPro;
    public static string dice1Result;
    public static string dice2Result;
    // Use this for initialization
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.diceNumber == 1)
        {
            if (dice1Result.ToString() == "")
            {
                textMeshPro.text = "";
            }

            textMeshPro.text = dice1Result.ToString();
        }
        else if (GameManager.instance.diceNumber == 2)
        {

            if (dice1Result.ToString() == "" && dice2Result.ToString() == "")
            {
                textMeshPro.text = "";
            }
            else
            {
                if(dice1Result.ToString() == "" || dice2Result.ToString() == "")
                {
                    textMeshPro.text = "";
                } else
                {
                    int result1 = Int32.Parse(dice1Result.ToString());
                    int result2 = Int32.Parse(dice2Result.ToString());
                    int result = result1 + result2;
                    textMeshPro.text = result.ToString();
                }
                
            }

        }

    }
}
