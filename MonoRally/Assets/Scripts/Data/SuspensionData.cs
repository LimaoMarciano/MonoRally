using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "SuspensionData", menuName = "RobotRally/Suspention", order = 3)]
public class SuspensionData : ScriptableObject {

	public string model;
	public string manufacturer;
	public Sprite sprite;
	public float stiffness = 5;
	public float damping = 0.5f;
}
