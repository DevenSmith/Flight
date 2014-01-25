using UnityEngine;
using System.Collections;

public class DBZFlight : MonoBehaviour {
	public KeyCode forwardKey;
	public KeyCode backwardKey;
	public KeyCode strafeLeftKey;
	public KeyCode strafeRightKey;
	public KeyCode rotateLeftKey;
	public KeyCode rotateRightKey;
	public KeyCode riseKey;
	public KeyCode lowerKey;

	public KeyCode increaseSpeedKey;
	public KeyCode decreaseSpeedKey;
	public KeyCode stopKey;

	public float flightSpeed = 0.0f;
	public float normalFlightSpeed = 25.0f;
	public float SuperFlightSpeed = 75f;

	public Camera myCam;

	KeyCode lastKeyPressed = KeyCode.Dollar;
	KeyCode keyJustPressed = KeyCode.Semicolon;

	public float keyPressTimeLeft;
	public float timeToPressAgain;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		keyJustPressed = KeyCode.Ampersand;
		//forward/backward controls
		if(Input.GetKey(forwardKey))
			transform.Translate(transform.forward * flightSpeed * Time.deltaTime,Space.World);
		if(Input.GetKey(backwardKey))
			transform.Translate(-transform.forward * flightSpeed * Time.deltaTime,Space.World);

		//strafe controls
		if(Input.GetKey(strafeLeftKey))
			transform.Translate(-transform.right * flightSpeed * Time.deltaTime,Space.World);
		if(Input.GetKey(strafeRightKey))
			transform.Translate(transform.right * flightSpeed * Time.deltaTime,Space.World);

		//rotate 90 degrees controls
		if(Input.GetKeyDown(rotateLeftKey))
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 90.0f, transform.eulerAngles.z);
			myCam.transform.eulerAngles = transform.eulerAngles;
		}
		if(Input.GetKeyDown(rotateRightKey))
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90.0f, transform.eulerAngles.z);
			myCam.transform.eulerAngles = transform.eulerAngles;
		}

		//rise or lower controls
		if(Input.GetKey(riseKey))
			transform.Translate(transform.up * flightSpeed * Time.deltaTime,Space.World);
		if(Input.GetKey(lowerKey))
			transform.Translate(-transform.up * flightSpeed * Time.deltaTime,Space.World);

		if(Input.GetKeyDown(increaseSpeedKey))
		{
			if(flightSpeed == 0.0f)
				flightSpeed = normalFlightSpeed;
			else if(flightSpeed == normalFlightSpeed)
				flightSpeed = SuperFlightSpeed;
		}

		if(Input.GetKeyDown(decreaseSpeedKey))
		{
			if(flightSpeed == SuperFlightSpeed)
				flightSpeed = normalFlightSpeed;
			else if(flightSpeed == normalFlightSpeed)
				flightSpeed = 0.0f;
		}

		//if(Input.anyKeyDown)
		//{
			//KeyCode keyJustPressed = Event.current.keyCode;


		if(Input.GetKeyDown(forwardKey))
		{
			keyJustPressed = forwardKey;
			//keyPressTimeLeft = timeToPressAgain;
		}
		if(Input.GetKeyDown(backwardKey))
		{
			keyJustPressed = backwardKey;
			//keyPressTimeLeft = timeToPressAgain;
		}
		if(Input.GetKeyDown(strafeRightKey))
		{
			keyJustPressed = strafeRightKey;
			//keyPressTimeLeft = timeToPressAgain;
		}
		if(Input.GetKeyDown(strafeLeftKey))
		{
			keyJustPressed = strafeLeftKey;
			//keyPressTimeLeft = timeToPressAgain;
		}
		if(Input.GetKeyDown(riseKey))
		{
			keyJustPressed = riseKey;
			//keyPressTimeLeft = timeToPressAgain;
		}
		if(Input.GetKeyDown(lowerKey))
		{
			keyJustPressed = lowerKey;

		}

		//string keyJustPressed = Input.inputString.;
		if(keyJustPressed == lastKeyPressed && keyPressTimeLeft > 0.0f)
		{
			//print ("same key " + keyJustPressed);
			if(keyJustPressed == forwardKey)
			{
				//print("jump forward");
				transform.Translate(transform.forward * flightSpeed * 10 , Space.World);
			}
			if(keyJustPressed == backwardKey)
				transform.Translate(-transform.forward * flightSpeed * 10, Space.World);
			if(keyJustPressed == strafeRightKey)
				transform.Translate(transform.right * flightSpeed * 10, Space.World);
			if(keyJustPressed == strafeLeftKey)
				transform.Translate(-transform.right * flightSpeed * 10, Space.World);
			if(keyJustPressed == riseKey)
				transform.Translate(transform.up * flightSpeed * 10, Space.World);
			if(keyJustPressed == lowerKey)
				transform.Translate(-transform.up * flightSpeed * 10, Space.World);

		}



		if(keyJustPressed  != KeyCode.Ampersand)
		{
			lastKeyPressed = keyJustPressed;
			keyPressTimeLeft = timeToPressAgain;
		}
		


		//}
		keyPressTimeLeft -= Time.deltaTime;

	
	}
}
