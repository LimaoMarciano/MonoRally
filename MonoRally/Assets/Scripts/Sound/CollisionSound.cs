using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class CollisionSound : MonoBehaviour {

	public CollisionDetector detector;
	public string collisionStateEvent;

	private EventInstance grindSound; 
	private bool isGrinding = false;

	// Use this for initialization
	void Start () {
		detector.OnCollision += OnCollision;
		detector.OnDragging += OnDragging;

		grindSound = FMODUnity.RuntimeManager.CreateInstance ("event:/Collision/MetalScratch");
		if (grindSound != null) {

			grindSound.start ();
			FMODUnity.RuntimeManager.AttachInstanceToGameObject (grindSound, transform, null);

		}
	}
		

	void OnDisable () {
		detector.OnCollision -= OnCollision;
		detector.OnDragging -= OnDragging;
		grindSound.release ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrinding) {
			if (detector.dragging.gameObject.layer == LayerMask.NameToLayer ("Road")) {
				if (detector.dragging.relativeVelocity.magnitude > 0.1f) {
					grindSound.setParameterValue ("Active", 1);
				} else {
					grindSound.setParameterValue ("Active", 0);
				}
			}

		} else {
			grindSound.setParameterValue ("Active", 0);
		}

		isGrinding = false;
	}

	void OnCollision () {
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

	void OnDragging () {
		isGrinding = true;
	}
}
