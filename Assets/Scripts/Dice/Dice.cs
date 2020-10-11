using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 diceVelocity;
    public static Dice instance;
    public int count = 0;
    private bool setpos = false;
    private bool holding = false;
    private float touchableArea = Screen.height / 2 * 1.7f;


    private float timeRemainingVideo = 40;


    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {


        /*if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log(Input.mousePosition);
            UnityEngine.Debug.Log(Screen.height / 2 * 1.76f);
        }*/

        if (diceVelocity != null)
        {
            diceVelocity = rb.velocity;
        }


        var fingerCount = 0;
        foreach (var touch in Input.touches)
        {

            if (touch.position.y < touchableArea)
            {

                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    fingerCount++;
                    holding = false;
                }


                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    holding = true;
                    if (timeRemainingVideo > 0)
                    {
                        timeRemainingVideo -= Time.deltaTime;
                        UnityEngine.Debug.Log("time : "+ timeRemainingVideo);
                    }
                    else
                    {
                        //Debug.Log("Show Video Ad");
                        AdManager.instance.ShowVideoAd();
                        AdManager.instance.HideBannerAd();
                        GameManager.instance.isVideoAdActive = true;
                        timeRemainingVideo = 30;
                    }  
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) || (fingerCount > 0 && !holding))
        {

            //UnityEngine.Debug.Log("AHMET");
            //UnityEngine.Debug.Log(GameManager.instance.diceNumber);

            float dirX = Random.Range(10000, 500000);
            float dirY = Random.Range(10000, 500000);
            float dirZ = Random.Range(10000, 500000);
            float posX = Random.Range(-2, 2);
            float posZ = Random.Range(-8, 0);
            float posY = Random.Range(3, 6);



            transform.position = new Vector3(posX, posY, posZ);
            transform.Rotate(Vector3.down, 2000f * Time.deltaTime);
            transform.Rotate(Vector3.left, 2000f * Time.deltaTime);
            //transform.rotation = Quaternion.identity;
            rb.AddForce(Physics.gravity * 20f, ForceMode.Acceleration);
            rb.AddTorque(dirX, dirY, dirZ);

        }
        else if (Input.GetKey(KeyCode.Space) || (fingerCount > 0 && holding))
        {
            if (!setpos)
            {
                float posX = Random.Range(-2, 2);
                float posZ = Random.Range(-8, 0);
                float posY = Random.Range(3, 6);
                transform.position = new Vector3(posX, posY, posZ);
                setpos = true;

            }
            else if (setpos)
            {
                transform.Rotate(Vector3.down, 1500f * Time.deltaTime);
                transform.Rotate(Vector3.left, 1500f * Time.deltaTime);
            }

            rb.AddForce(Physics.gravity, ForceMode.Acceleration);
        }
    }

    
}
