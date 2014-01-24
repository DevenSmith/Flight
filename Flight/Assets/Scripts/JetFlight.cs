using UnityEngine;
using System.Collections;

public class JetFlight : MonoBehaviour {

	public KeyCode accelerateKey;
	public KeyCode decelerateKey;
	public KeyCode rollLeftKey;
	public KeyCode rollRightKey;
	public KeyCode yawLeftKey;
	public KeyCode yawRightKey;
	public KeyCode pitchUpKey;
	public KeyCode pitchDownKey;

	public float minimumVelocity;
	public float maxVelocity;
	public float drag = 1;

	float acceleration = 0.0f;
	float maxAcceleration;
	public float velocity = 0.0f;
	public GUIText speedText;
	public Vector3 rotation;

	//Vector3 direction;

	// Use this for initialization
	void Start () {
		maxAcceleration = maxVelocity;
	}
	
	// Update is called once per frame
	void Update () {

		//Camera.main.transform.position = new Vector3(0, 0.6604233f, -0.6326837f);

		//set a vector3 to handle the rotation then adjust the transform to match
		velocity = rigidbody.velocity.magnitude;

		//direction = transform.forward;

		//speed up or down
		if(Input.GetKey(accelerateKey))
		{
			if(acceleration < maxAcceleration)
				acceleration += .2f;
		}
		if(Input.GetKey(decelerateKey))
		{
			acceleration -= .1f;
			if(acceleration < 0)
				acceleration = 0;
		}

		if(acceleration > 0)
		{
			rigidbody.AddForce(transform.forward * acceleration, ForceMode.Force);
			//acceleration -= .1f;
		}

		//roll left or right
		if(Input.GetKey(rollLeftKey))
		{
			rotation = new Vector3(rotation.x, rotation.y, rotation.z + 1); 
		}
		if(Input.GetKey(rollRightKey))
		{
			rotation = new Vector3(rotation.x, rotation.y, rotation.z - 1); 
		}

		//yaw/turn left or right
		if(Input.GetKey(yawLeftKey))
		{
			rotation = new Vector3(rotation.x, rotation.y - .5f, rotation.z); 
		}
		if(Input.GetKey(yawRightKey))
		{
			rotation = new Vector3(rotation.x, rotation.y + .5f, rotation.z);  
		}

		//pitch up or down
		if(Input.GetKey(pitchUpKey))
		{
			rotation = new Vector3(rotation.x - .5f, rotation.y , rotation.z); 
		}
		if(Input.GetKey(pitchDownKey))
		{
			rotation = new Vector3(rotation.x + .5f, rotation.y , rotation.z); 
		}


		//keep the velocity in bounds
		if(rigidbody.velocity.magnitude < minimumVelocity)
		{
			rigidbody.drag = 0;
		}
		else
		{
			rigidbody.drag = drag;
		}

		if(rigidbody.velocity.magnitude > maxVelocity)
		{

		}
		transform.eulerAngles = rotation;
		rigidbody.velocity = transform.forward * velocity;
		speedText.text = rigidbody.velocity.magnitude + " MPH";

	}
}
