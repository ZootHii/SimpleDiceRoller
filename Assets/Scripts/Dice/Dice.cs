using UnityEngine;

public class Dice : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 diceVelocity;
    public static Dice instance;
    bool setpos = false;
    bool holding = false;

    private void Awake()
    {
        instance = this;

    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (diceVelocity != null)
        {
            diceVelocity = rb.velocity;
        }


        var fingerCount = 0;
        foreach (var touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
                holding = false;
            }


            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                holding = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || (fingerCount > 0 && !holding))
        {

            Debug.Log("AHMET");
            Debug.Log(GameManager.instance.diceNumber);
            //Result.diceResult = 0;
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

        if (Input.GetKey(KeyCode.Space) || (fingerCount > 0 && holding))
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
