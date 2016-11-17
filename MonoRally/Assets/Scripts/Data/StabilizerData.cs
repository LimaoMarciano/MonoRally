using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "StabilizerData", menuName = "RobotRally/Stabilizer", order = 5)]
public class StabilizerData : ScriptableObject {

	public string model;
	public string manufacturer;
	public float angleLimit = 90f;
	public float toAngularSpeed = 10f;
	public float maxAngularSpeed = 200f;
	public float maxTorque = 2000.0f;
	public float gain = 5f;
}
