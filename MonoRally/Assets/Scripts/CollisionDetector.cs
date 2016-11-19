using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	public Collision2D collision;
	public Collision2D dragging;

	public delegate void CollisionEvent();
	public event CollisionEvent OnCollision;

	public delegate void DraggingEvent();
	public event DraggingEvent OnDragging;

	void OnCollisionEnter2D (Collision2D col) {
		collision = col;
		if (OnCollision != null) {
			OnCollision ();
		}
	}

	void OnCollisionStay2D (Collision2D col) {
		dragging = col;
		if (OnDragging != null) {
			OnDragging ();
		}
	}
}
