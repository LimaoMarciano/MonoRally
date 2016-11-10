using UnityEngine;
using System.Collections;

public class BrakesDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar brakeTorque;

	// Use this for initialization
	void Start () {
		brakeTorque.SetMaxValue (robot.brakes.brakeTorque);
	}
	
	// Update is called once per frame
	void Update () {
		brakeTorque.value = robot.brakes.GetBrakeTorque ();
	}
}
