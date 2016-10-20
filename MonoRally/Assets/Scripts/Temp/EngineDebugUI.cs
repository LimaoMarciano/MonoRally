using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineDebugUI : MonoBehaviour {

//	public Engine engine;
	public Robot robot;
	public Fillbar speed;
	public Fillbar wheelSpeed;
	public Fillbar torque;

	// Use this for initialization
	void Start () {
		speed.SetMaxValue (robot.engine.maxSpeed);
		speed.SetLabel ("Engine speed");
		torque.SetMaxValue (robot.engine.maxTorque);
		torque.SetLabel ("Engine torque");
		wheelSpeed.SetMaxValue (robot.engine.maxSpeed);
		wheelSpeed.SetLabel ("Wheel speed");
	}
	
	// Update is called once per frame
	void Update () {
		speed.value = robot.engine.GetSpeed ();
		torque.value = robot.engine.GetTorque ();
		wheelSpeed.value = Mathf.Abs(robot.wheelJoint.jointSpeed);
	}
}
