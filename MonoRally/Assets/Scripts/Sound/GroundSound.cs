using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class GroundSound : MonoBehaviour {

	private Robot robot;
	private bool isGrounded;
	private Rigidbody2D rb;

	[FMODUnity.EventRef]
	public string soundStateEvent;
	private EventInstance soundState;

	// Use this for initialization
	void Start () {

		robot = RaceManager.instance.robot;
		soundState = FMODUnity.RuntimeManager.CreateInstance (soundStateEvent);

		if (soundState != null) {

			soundState.start ();
			GameObject wheel = RaceManager.instance.robot.wheel.gameObject;
			rb = wheel.GetComponent<Rigidbody2D> ();
			FMODUnity.RuntimeManager.AttachInstanceToGameObject (soundState, wheel.transform, null);

		}
	}
	
	// Update is called once per frame
	void Update () {

		float speed = Mathf.Abs (rb.velocity.magnitude);
		float speedRatio = Mathf.Clamp01 (speed / 20f);
		float tyreSlip = Mathf.Abs(robot.wheel.GetSlip ());

		if (robot.wheel.isGrounded) {

			if (tyreSlip > 3) {
				soundState.setParameterValue ("Sliding", 1);
			} else {
				soundState.setParameterValue ("Sliding", 0);
			}

			if (speed > 1) {
			
				soundState.setParameterValue ("Enable", 1);
				soundState.setParameterValue ("Speed", speedRatio);

			} else {
				soundState.setParameterValue ("Enable", 0);

			}
		} else {

			soundState.setParameterValue ("Enable", 0);
			soundState.setParameterValue ("Sliding", 0);
		}

	}
}
