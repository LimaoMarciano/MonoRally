using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BoostData", menuName = "RobotRally/Boost", order = 9)]
public class BoostData : ScriptableObject {

	public string model;
	public string manufacturer;
	public float force;
	public float chargeTime;
}
