using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Rigidbody diceRigidBody;

    public Vector3 diceVelocity;


    public static Dice instance;

    private bool isPositionSet = false;
    private bool isHolding = false;
    private readonly float touchableArea = Screen.height / 2 * 1.7f;
    private float timeRemainingVideo = 40;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {

        diceVelocity = diceRigidBody.velocity;


        var fingerCount = 0;
        foreach (var touch in Input.touches)
        {
            if (touch.position.y < touchableArea)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    fingerCount++;
                    isHolding = false;
                }

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    isHolding = true;
                    if (timeRemainingVideo > 0)
                    {
                        timeRemainingVideo -= Time.deltaTime;
                    }
                    else
                    {
                        AdManager.instance.ShowVideoAd();
                        AdManager.instance.HideBannerAd();
                        GameManager.instance.isVideoAdActive = true;
                        timeRemainingVideo = 40;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || (fingerCount > 0 && !isHolding))
        {

            float dirX = Random.Range(10000, 500000);
            float dirY = Random.Range(10000, 500000);
            float dirZ = Random.Range(10000, 500000);
            float posX = Random.Range(-2, 2);
            float posY = Random.Range(3, 6);
            float posZ = -8;
            

            transform.position = new Vector3(posX, posY, posZ);
            transform.Rotate(Vector3.down, 2000f * Time.deltaTime);
            transform.Rotate(Vector3.left, 2000f * Time.deltaTime);

            diceRigidBody.AddForce(Physics.gravity * 5f, ForceMode.Acceleration);
            diceRigidBody.AddForce(Vector3.forward * Time.deltaTime * 1000, ForceMode.VelocityChange); // atış hızı olarak 500 1000 2000 
            diceRigidBody.AddTorque(dirX, dirY, dirZ, ForceMode.VelocityChange);

        }
        else if (Input.GetKey(KeyCode.Space) || (fingerCount > 0 && isHolding))
        {
            if (!isPositionSet)
            {
                float posX = Random.Range(-2, 2);
                float posY = Random.Range(3, 6);
                float posZ = -8;
                
                transform.position = new Vector3(posX, posY, posZ);
                isPositionSet = true;
            }
            else if (isPositionSet)
            {
                transform.Rotate(Vector3.down, 1500f * Time.deltaTime);
                transform.Rotate(Vector3.left, 1500f * Time.deltaTime);
            }
        }
        
    }
}
