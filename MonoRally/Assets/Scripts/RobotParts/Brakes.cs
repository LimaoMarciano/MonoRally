using UnityEngine;
using System.Collections;

public class Brakes : MonoBehaviour {

	public float brakeTorque = 0f;

	private Robot robot;
	private float input = 0;
	private SpriteRenderer discSprite;
	private SpriteRenderer caliperSprite;
	private GameObject caliperContainer;
	private GameObject caliperObject;
	private Vector3 caliperOffset;
	private Vector3 caliperRotation;
	private Vector3 caliperTravel;

	void Update () {
		UpdateCaliperPosition ();
	}
		
	void FixedUpdate () {
		robot.wheel.ApplyBrakeForce (brakeTorque * input);
	}

	//Public Methods
	//***********************************************************************************
	//
	public void SetInput (float value) {
		input = value;
	}

	public float GetBrakeTorque () {
		return brakeTorque * input;
	}

	public void LoadData (BrakeData data) {
		robot = GetComponentInParent<Robot> ();

		caliperOffset = new Vector3 (data.caliperOffset, 0, 0);
		caliperRotation = new Vector3 (0, 0, data.caliperRotation);
		caliperTravel = new Vector3 (data.caliperTravel, 0, 0);
		brakeTorque = data.brakeTorque;

		discSprite = gameObject.AddComponent<SpriteRenderer>();
		discSprite.sprite = data.disc;
		discSprite.sortingOrder = 4;

		caliperContainer = new GameObject ();
		caliperContainer.name = "Caliper Container";
		caliperContainer.transform.SetParent (robot.body.gameObject.transform);
		caliperContainer.transform.localRotation = Quaternion.Euler (caliperRotation);

		caliperObject = new GameObject ();
		caliperObject.name = "Caliper";
		caliperObject.transform.SetParent (caliperContainer.transform);
		caliperObject.transform.localPosition = caliperOffset;
		caliperObject.transform.localRotation = Quaternion.identity;
		caliperSprite = caliperObject.AddComponent<SpriteRenderer> ();
		caliperSprite.sprite = data.caliper;
		caliperSprite.sortingOrder = 5;

		Debug.Log ("Brake data loaded.");
	}

	//Private methods
	//**********************************************************************************
	//
	private void UpdateCaliperPosition () {
		caliperContainer.transform.position = robot.wheel.gameObject.transform.position;
		caliperObject.transform.localPosition = caliperOffset - (caliperTravel * input);
	}

}
