using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "JumpMechanismData", menuName = "RobotRally/Jump mechanism", order = 6)]
public class JumpMechanismData : ScriptableObject {

	public string model;
	public string manufacturer;
	public float jumpForce = 200;
	public float jumpBoostForce = 2000;
	public float jumpBoostTimeLimit = 0.2f;
}
