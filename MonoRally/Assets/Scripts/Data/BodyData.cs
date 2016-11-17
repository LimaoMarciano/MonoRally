using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BodyData", menuName = "RobotRally/Body", order = 1)]
public class BodyData : ScriptableObject {

	public string model;
	public string manufacturer;
	public Sprite sprite;
	public PolygonColliderData colliderPath;
	public Vector3 wheelPosition;
	public Vector3 boostPosition;
	public float mass;
	public float drag;
}
