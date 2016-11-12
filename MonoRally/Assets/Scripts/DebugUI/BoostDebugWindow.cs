using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar boostBar;

	private float boostMaxForce;

	// Use this for initialization
	void Start () {
		robot = RaceManager.instance.robot;

		if (robot) {
			boostMaxForce = robot.boost.GetBoostMaxForce ();
			boostBar.SetMaxValue (boostMaxForce);
		}

		boostBar.SetLabel ("Boost force");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (robot) {
			boostBar.value = boostMaxForce * robot.boost.GetChargeValue ();
		}
	}
}
