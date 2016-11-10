using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransmissionDebugWindow : MonoBehaviour {
	public Robot robot;

	public Fillbar outputSpeed;
	public Fillbar outputTorque;
	public Fillbar clutch;
	public DebugValue currentGear;
	public DebugValue currentGearRatio;

	private Transmission transmission;

	// Use this for initialization
	void Start () {
		transmission = robot.transmission;
		float[] gears = transmission.GetGears ();

		outputSpeed.SetLabel ("Speed");
		outputTorque.SetLabel ("Torque");
		clutch.SetLabel ("Clutch");
		currentGear.SetLabel ("Gear");
		currentGearRatio.SetLabel ("Gear ratio");

		outputSpeed.SetMaxValue (robot.engine.maxSpeed / gears [gears.Length - 1]);
		outputTorque.SetMaxValue (robot.engine.maxTorque * gears [0]);
		clutch.SetMaxValue (1);
		clutch.isFractional = true;
	}
	
	// Update is called once per frame
	void Update () {
		outputSpeed.value = transmission.GetSpeed ();
		outputTorque.value = transmission.GetTorque ();
		clutch.value = transmission.GetClutch ();
		currentGear.SetValue (transmission.GetCurrentGear ());
		currentGearRatio.SetValue (transmission.GetCurrentGearRatio (), true);
	}
}
