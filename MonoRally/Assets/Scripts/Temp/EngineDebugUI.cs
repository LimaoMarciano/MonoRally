using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineDebugUI : MonoBehaviour {

	public Engine engine;
	public Fillbar speed;
	public Fillbar torque;

	// Use this for initialization
	void Start () {
		speed.SetMaxValue (engine.maxSpeed);
		speed.SetLabel ("Engine speed");
		torque.SetMaxValue (engine.maxTorque);
		torque.SetLabel ("Engine torque");
	}
	
	// Update is called once per frame
	void Update () {
		speed.value = engine.GetSpeed ();
		torque.value = engine.GetTorque ();
	}
}
