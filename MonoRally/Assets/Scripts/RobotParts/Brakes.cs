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
	private Vector3 caliperOffset = new Vector3 (0.15f, 0, 0);
	private Vector3 caliperRotation = new Vector3 (0, 0, 0);
	private Vector3 caliperTravel = new Vector3 (0.05f, 0, 0);

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		caliperContainer.transform.position = robot.wheel.gameObject.transform.position;


		caliperObject.transform.localPosition = caliperOffset - (caliperTravel * input);
	}

	// Update is called once per frame
	void FixedUpdate () {
		robot.wheel.ApplyBrakeForce (brakeTorque * input);
	}

	public void SetInput (float value) {
		input = value;
	}

	public void LoadData (BrakeData data) {
		robot = GetComponentInParent<Robot> ();

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

}
