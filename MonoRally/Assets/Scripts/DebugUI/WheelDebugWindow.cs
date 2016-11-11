using UnityEngine;
using System.Collections;

public class WheelDebugWindow : MonoBehaviour {

	public Robot robot;
	public Fillbar angularVelocity;
	public DebugValue velocity;
	public DebugBoolean groundedBool;

	// Use this for initialization
	void Start () {
		angularVelocity.SetLabel ("AngVelocity");
		velocity.SetLabel ("Velocity");
		groundedBool.SetLabel ("Is grounded?");
	}
	
	// Update is called once per frame
	void Update () {
		angularVelocity.SetMaxValue (robot.engine.maxSpeed / robot.transmission.GetCurrentGearRatio ());
		angularVelocity.value = Mathf.Abs(robot.wheel.GetAngularVelocity ());
		velocity.SetValue (robot.wheel.GetCurrentSpeed (), false);
		groundedBool.SetValue (robot.wheel.isGrounded);
	}
}
