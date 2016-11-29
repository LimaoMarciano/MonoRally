using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class EngineSound : MonoBehaviour {

	[Range(0, 1)]
	public float engineRev;

	[FMODUnity.EventRef]
	public string EngineStateEvent;
	private EventInstance engineState;

	// Use this for initialization
	void Start () {
		engineState = FMODUnity.RuntimeManager.CreateInstance (EngineStateEvent);
		if (engineState != null) {
			engineState.start ();

			GameObject body = RaceManager.instance.robot.body.gameObject;
			Rigidbody rb = RaceManager.instance.robot.body.GetComponent<Rigidbody> ();

			FMODUnity.RuntimeManager.AttachInstanceToGameObject (engineState, body.transform, null);
		}
	}

	void OnDisable () {
		engineState.stop (STOP_MODE.ALLOWFADEOUT);
	}
	
	// Update is called once per frame
	void Update () {
		if (engineState != null) {
			engineState.setParameterValue ("Rev", engineRev);
		}
	}
}
