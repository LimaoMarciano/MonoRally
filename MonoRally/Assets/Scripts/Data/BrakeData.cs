using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BrakeData", menuName = "RobotRally/Brake", order = 6)]
public class BrakeData : ScriptableObject {

	public string model;
	public string manufacturer;
	public float brakeTorque = 200;
	public Sprite disc;
	public Sprite caliper;
}
