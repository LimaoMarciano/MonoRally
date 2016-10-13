using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineDebugUI : MonoBehaviour {

	public Engine engine;
	public Fillbar speed;
	public Fillbar wheelSpeed;
	public Fillbar torque;

	// Use this for initialization
	void Start () {
		speed.SetMaxValue (engine.maxSpeed);
		speed.SetLabel ("Engine speed");
		torque.SetMaxValue (engine.maxTorque);
		torque.SetLabel ("Engine torque");
		wheelSpeed.SetMaxValue (engine.maxSpeed);
		wheelSpeed.SetLabel ("Wheel speed");
	}
	
	// Update is called once per frame
	void Update () {
		speed.value = engine.GetSpeed ();
		torque.value = engine.GetTorque ();
		wheelSpeed.value = Mathf.Abs(engine.wheelJoint.jointSpeed);
	}
}
