using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class WheelSound : MonoBehaviour {

	public CollisionDetector detector;
	public string collisionStateEvent = "event:/Collision/Landing";

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
			if (detector.collision.relativeVelocity.magnitude > 3) {
				FMODUnity.RuntimeManager.PlayOneShot (collisionStateEvent, transform.position);
			}

		}
	}
}
