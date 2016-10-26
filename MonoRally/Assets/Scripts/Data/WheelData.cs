using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "WheelData", menuName = "RobotRally/Wheel", order = 3)]
public class WheelData : ScriptableObject {

	public string model;
	public string manufacturer;
	public Sprite sprite;
	public float radius = 0.43f;
	public float mass = 15;
	public float drag = 0.1f;
	public float angularDrag  = 0.1f;
	public float friction = 0.8f;
	public float bounciness = 0.1f;
}
