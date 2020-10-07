using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

	public Rigidbody rb;
	public Vector3 diceVelocity;
	public static Dice instance;
		

	private void Awake()
	{
		instance = this;
		
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(diceVelocity!= null)
        {
			diceVelocity = rb.velocity;
		}
		//Input.GetTouch(0).tapCount>0
		//Input.GetKeyDown(KeyCode.Space)
		var fingerCount = 0;
		foreach(var touch in Input.touches)
        {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}

		if (fingerCount > 0) {

			Debug.Log("AHMET");

			DiceNumber.diceNumber = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			float posX = Random.Range (-1, 1);
			float posZ = Random.Range (-1, 1);

			transform.position = new Vector3 (posX, 7, posZ);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 100);
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
