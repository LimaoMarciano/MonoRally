﻿using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {

	private Robot robot;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void LoadData (BodyData data) {
		robot = GetComponentInParent<Robot> ();

		gameObject.AddComponent<SpriteRenderer> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite = data.sprite;
		sprite.sortingOrder = 5;

		PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D> ();
		collider.SetPath (0, data.colliderPath.path);

		gameObject.AddComponent<Rigidbody2D> ();
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		rigidbody2D.mass = data.mass;
		rigidbody2D.drag = data.drag;
		rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;


		//Collision related FXs
		CollisionDetector detector = gameObject.AddComponent<CollisionDetector>();
		CollisionSound colSound = gameObject.AddComponent<CollisionSound> ();
		colSound.detector = detector;
		colSound.collisionStateEvent = data.collisionSound;

		Debug.Log ("Body data loaded.");

	}
		
}
