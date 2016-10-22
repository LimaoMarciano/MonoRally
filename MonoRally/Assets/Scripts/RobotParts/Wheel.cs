﻿using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	private Robot robot;
	private int facing = -1;
	private PhysicsMaterial2D physicsMaterial;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	public void ApplyMotorForce (float speed, float torque) {
		robot.wheelJoint.SetMotorValues (speed * facing, torque);
	}

	public void SetFacing (float direction) {
		if (direction > 0) {
			facing = -1;
		}

		if (direction < 0) {
			facing = 1;
		}
	}

	public void LoadData (WheelData data) {
		robot = GetComponentInParent<Robot> ();

		gameObject.AddComponent<SpriteRenderer> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite = data.sprite;
		sprite.sortingOrder = 1;

		gameObject.AddComponent<CircleCollider2D> ();
		CircleCollider2D collider = GetComponent<CircleCollider2D> ();
		collider.radius = data.radius;
		physicsMaterial = new PhysicsMaterial2D ();
		physicsMaterial.friction = data.friction;
		physicsMaterial.bounciness = data.bounciness;
		collider.sharedMaterial = physicsMaterial;

		gameObject.AddComponent<Rigidbody2D> ();
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		rigidbody2D.mass = data.mass;
		rigidbody2D.drag = data.drag;
		rigidbody2D.angularDrag = data.angularDrag;
		rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

	}
}
