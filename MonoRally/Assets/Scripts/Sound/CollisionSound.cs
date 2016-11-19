using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class CollisionSound : MonoBehaviour {

	public CollisionDetector detector;
	public string collisionStateEvent;

	// Use this for initialization
	void Start () {
		detector.OnCollision += OnCollision;
	}
		

	void OnDisable () {
		detector.OnCollision -= OnCollision;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollision () {
		Debug.Log ("Collided!");
		if (detector.collision.gameObject.layer == LayerMask.NameToLayer ("Road")) {
			
			EventInstance sound = FMODUnity.RuntimeManager.CreateInstance (collisionStateEvent);
			if (detector.collision.relativeVelocity.magnitude > 3) {
				sound.setParameterValue ("Force", 1);
			} else {
				sound.setParameterValue ("Force", 0);
			}

			sound.set3DAttributes (FMODUnity.RuntimeUtils.To3DAttributes (transform, null));
			sound.start();
			sound.release();

		}
	}

}
