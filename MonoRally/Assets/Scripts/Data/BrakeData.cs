using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BrakeData", menuName = "RobotRally/Brake", order = 7)]
public class BrakeData : ScriptableObject {

	public string model;
	public string manufacturer;
	public Sprite disc;
	public Sprite caliper;
	public float brakeTorque = 200;
	public float caliperOffset = 0.15f;
	public float caliperTravel = 0.05f;
	public float caliperRotation = 0;

}
