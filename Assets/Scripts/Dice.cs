using UnityEngine;

public class Dice : MonoBehaviour
{
    public static Dice Instance;
    public Rigidbody diceRigidBody;
    public Rigidbody dice2RigidBody;
    private bool isPositionSet;
    private bool isHolding;
    private readonly float touchableArea = (Screen.height / 2f) * 1.7f;
    private float timeRemainingVideo = 40;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        F();
    }

    private void F()
    {
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
                        AdManager.ShowVideoAd();
                        AdManager.HideBannerAd();
                        GameManager.Instance.isVideoAdActive = true;
                        timeRemainingVideo = 40;
                    }
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || (fingerCount > 0 && !isHolding))
        {
            float posX = Random.Range(-2, 2);
            float posY = Random.Range(3, 6);
            const float posZ = -8;

            transform.position = new Vector3(posX, posY, posZ);
            transform.Rotate(Vector3.down * Time.deltaTime);
            transform.Rotate(Vector3.left * Time.deltaTime);

            diceRigidBody.AddForce(Physics.gravity * 5f, ForceMode.Acceleration);
            diceRigidBody.AddForce(Vector3.forward * (Time.deltaTime * 650), ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.Space) || (fingerCount > 0 && isHolding))
        {
            if (!isPositionSet)
            {
                float posX = Random.Range(-2, 2);
                float posY = Random.Range(3, 6);
                const float posZ = -8;

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
