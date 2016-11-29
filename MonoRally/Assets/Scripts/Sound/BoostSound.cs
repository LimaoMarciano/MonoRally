using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class BoostSound : MonoBehaviour {

	public Boost boost;

	private string soundStateEvent = "event:/Engine/BoostCharge";
	private string releaseStateEvent = "event:/Engine/BoostRelease";
	private EventInstance soundEvent;

	private bool isSoundStarted = false;

	// Use this for initialization
	void Start () {
		
		boost = RaceManager.instance.robot.boost;
		soundEvent = FMODUnity.RuntimeManager.CreateInstance (soundStateEvent);

		boost.OnBoostRelease += BoostReleaseSound;

	}

	void OnDisable () {
		boost.OnBoostRelease -= BoostReleaseSound;
	}

	// Update is called once per frame
	void Update () {
		float charge = boost.GetChargeValue ();

		if (charge > 0) {
			if (!isSoundStarted) {
				soundEvent.start ();
				FMODUnity.RuntimeManager.AttachInstanceToGameObject (soundEvent, boost.transform, null);
				isSoundStarted = true;
			}

			soundEvent.setParameterValue ("Charge", charge);

		}
	}

	private void BoostReleaseSound () {
		isSoundStarted = false;
		soundEvent.stop (STOP_MODE.ALLOWFADEOUT);
		FMODUnity.RuntimeManager.PlayOneShot (releaseStateEvent, boost.transform.position);
	}
		
}
