using UnityEngine;
using System.Collections;


public enum FlightModes {Jet, DBZ, Superman, Helicopter};
public class FlightManager : MonoBehaviour {
	FlightModes flightMode;

	public KeyCode jetKey;
	public KeyCode dbzKey;
	public KeyCode supermanKey;
	public KeyCode helicopterKey;

	public JetFlight jetScript;
	public GameObject jetObj;

	public DBZFlight DBZScript;

	public SupermanFlight superScript;
	public GameObject superMan;

	public GameObject speedGui;

	// Use this for initialization
	void Start () {
		DisableSuperman();
		SetJet();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(jetKey))
		{
			DisableDBZ();
			DisableSuperman();
			SetJet();
		}
		if(Input.GetKeyDown(dbzKey))
		{
			DisableJet();
			DisableSuperman();
			SetDBZ();
		}
		if(Input.GetKeyDown(supermanKey))
		{
			DisableDBZ();
			DisableJet();
			SetSuperman();
		}
		if(Input.GetKeyDown(helicopterKey))
		{
			DisableDBZ();
			DisableJet();
			DisableSuperman();
		}
	}

	void SetJet()
	{
		transform.eulerAngles = Vector3.zero;
		Camera.main.transform.position = new Vector3(0, 0.6604233f, -0.6326837f) + transform.position;
		Camera.main.transform.eulerAngles = transform.eulerAngles;
		rigidbody.velocity = new Vector3(0,0,0);
		jetScript.enabled = true;
		jetObj.SetActive(true);
	}

	void DisableJet()
	{
		rigidbody.velocity = new Vector3(0,0,0);
		jetScript.enabled = false;
		jetObj.SetActive(false);
	}

	void SetDBZ()
	{
		DBZScript.enabled = true;
		transform.eulerAngles = Vector3.zero;
		Camera.main.transform.position = transform.position;
		Camera.main.transform.eulerAngles = transform.eulerAngles;
		rigidbody.velocity = new Vector3(0,0,0);
	}

	void DisableDBZ()
	{
		DBZScript.enabled = false;
	}


	void SetSuperman()
	{
		superScript.enabled = true;
		superMan.SetActive(true);
		MouseLook lookScript = Camera.main.GetComponent<MouseLook>();
		lookScript.enabled = true;
	}

	void DisableSuperman()
	{
		superScript.enabled = false;
		superMan.SetActive(false);
		MouseLook lookScript = Camera.main.GetComponent<MouseLook>();
		lookScript.enabled = false;
	}
}
