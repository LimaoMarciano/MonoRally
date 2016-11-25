using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class BoostSound : MonoBehaviour {

	public Boost boost;

	private string soundStateEvent = "event:/Engine/BoostCharge";
	private string releaseStateEvent = "event:/Engine/BoostRelease";
	private EventInstance soundEvent;

	// Use this for initialization
	void Start () {
		
		boost = RaceManager.instance.robot.boost;
		soundEvent = FMODUnity.RuntimeManager.CreateInstance (soundStateEvent);
		FMODUnity.RuntimeManager.AttachInstanceToGameObject (soundEvent, boost.transform, null);

		boost.OnBoostRelease += BoostReleaseSound;

	}

	void OnDisable () {
		boost.OnBoostRelease -= BoostReleaseSound;
	}

	// Update is called once per frame
	void Update () {
		float charge = boost.GetChargeValue ();

		if (charge > 0) {
			soundEvent.start ();
			soundEvent.setParameterValue ("Charge", charge);
		} else {
			soundEvent.stop (STOP_MODE.ALLOWFADEOUT);
		}
	}

	private void BoostReleaseSound () {
		FMODUnity.RuntimeManager.PlayOneShot (releaseStateEvent, boost.transform.position);
	}
}
