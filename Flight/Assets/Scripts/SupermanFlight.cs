using UnityEngine;
using System.Collections;

public class SupermanFlight : MonoBehaviour {

	public KeyCode forwardKey;
	public KeyCode backwardKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode riseKey;
	public KeyCode lowerKey;
	public KeyCode speedIncreaseKey;
	public KeyCode speedDecreaseKey;
	public KeyCode speedStopKey;

	public Camera superCam;
	public float camDistance = 15.0f;
	public float flightSpeed = 0.0f;
	Vector3 flightDirection;

	public GUIText speedText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		flightDirection = Vector3.zero;
		SetSuperCam();

		if(Input.GetKey(forwardKey))
		{
			flightDirection += superCam.transform.forward;
		}
		if(Input.GetKey(backwardKey))
		{
			flightDirection += -superCam.transform.forward;
		}
		if(Input.GetKey(leftKey))
		{
			flightDirection += -superCam.transform.right;
		}
		if(Input.GetKey(rightKey))
		{
			flightDirection += superCam.transform.right;
		}

		if(Input.GetKey(riseKey))
		{
			flightDirection += superCam.transform.up;
		}
		if(Input.GetKey(lowerKey))
		{
			flightDirection += -superCam.transform.up;
		}

		if(Input.GetKeyDown(speedIncreaseKey))
		{
			if(flightSpeed <= 0)
				flightSpeed = 5;
			else
				flightSpeed *= 2;
		}

		if(Input.GetKeyDown(speedDecreaseKey))
		{
			if(flightSpeed > 5)
				flightSpeed /=2;
			else
				flightSpeed = 0;
		}
		if(Input.GetKeyDown(speedStopKey))
			flightSpeed = 0;
	
		//rotate superman to face the direction he is going
		transform.Translate(flightDirection.normalized * flightSpeed * Time.deltaTime);

		speedText.text = flightSpeed.ToString();

	}

	void SetSuperCam()
	{
		superCam.transform.position = transform.position + (-superCam.transform.forward * camDistance); 
	}
}
