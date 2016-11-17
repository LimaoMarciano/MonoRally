using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineDebugUI : MonoBehaviour {

//	public Engine engine;
	public Robot robot;
	public Fillbar speed;
	public Fillbar wheelSpeed;
	public Fillbar torque;
	public Fillbar boost;
	public Text gear;
	public Text speedometer;

	// Use this for initialization
	void Start () {
		speed.SetMaxValue (robot.engine.maxSpeed);
		speed.SetLabel ("Engine speed");
		torque.SetMaxValue (robot.engine.maxTorque);
		torque.SetLabel ("Engine torque");
		wheelSpeed.SetMaxValue (robot.engine.maxSpeed);
		wheelSpeed.SetLabel ("Wheel speed");
		boost.SetLabel ("Boost");
		boost.SetMaxValue (1);
	}
	
	// Update is called once per frame
	void Update () {
		speed.value = robot.engine.GetSpeed ();

		torque.SetMaxValue (robot.engine.maxTorque * robot.transmission.GetCurrentGearRatio ());
		torque.value = robot.transmission.GetTorque();

		wheelSpeed.SetMaxValue (robot.engine.maxSpeed / robot.transmission.GetCurrentGearRatio ());
		wheelSpeed.value = Mathf.Abs(robot.wheelJoint.jointSpeed);

		boost.value = robot.boost.GetChargeValue ();

		gear.text = robot.transmission.GetCurrentGear ().ToString ();
		float speedKmH = robot.wheel.GetCurrentSpeed () * 3.6f;
		speedometer.text = speedKmH.ToString("F0");
	}
}
