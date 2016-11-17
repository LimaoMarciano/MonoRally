using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {

	public Image needle;
	public Image redline;
	public Text velocity;
	public Text gear;
	public float minNeedle;
	public float maxNeedle;
	public float maxMotorSpeed;
	public float redlineMotorSpeed;
	public float motorSpeed;

	private Robot robot;
	private float range;

	// Use this for initialization
	void Start () {
		robot = RaceManager.instance.robot;
		maxMotorSpeed = robot.engine.maxSpeed;

		range = maxNeedle - minNeedle;
		Debug.Log (range);
		redline.fillAmount = 0.665f - ((redlineMotorSpeed * 0.665f) / maxMotorSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		float speed = robot.wheel.GetCurrentSpeed () * 3.6f;
		velocity.text = speed.ToString("F0") + "<size=24> km/h</size>";

		float currentGear = robot.transmission.GetCurrentGear() + 1;
		if (currentGear > 0) {
			gear.text = currentGear.ToString ();
		} else {
			gear.text = "N";
		}


		motorSpeed = robot.engine.GetSpeed ();
		float needleAngle = (range * (motorSpeed / maxMotorSpeed)) + minNeedle;
		needle.rectTransform.localRotation = Quaternion.Euler (new Vector3 (0, 0, needleAngle));
	}
}
