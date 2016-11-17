using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "TransmissionData", menuName = "RobotRally/Transmission", order = 8)]
public class TransmissionData : ScriptableObject {
	public string model;
	public string manufacturer;
	public float[] gears;
}
