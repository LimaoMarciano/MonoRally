using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceManager : MonoBehaviour {

	public static RaceManager instance;

	private List<VehicleSpawn> vehicleSpawns = new List<VehicleSpawn>();
	public VehicleConfig vehicleConfig;
	public Robot robot;

	void Awake () {
		if (instance == null) {
			
			instance = this;

		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		CreateVehicle ();
	}

	// Use this for initialization
	void Start () {
		if (robot != null) {

			if (vehicleSpawns.Count > 0) {
				robot.gameObject.transform.position = vehicleSpawns [0].gameObject.transform.position;
			} else {
				Debug.LogWarning ("No spawn points found. Vehicle will spawn at origin.");
			}
		} else {
			Debug.LogWarning ("Robot failed to initialize.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddSpawnPoint (VehicleSpawn spawn) {
		vehicleSpawns.Add (spawn);
	}

	void CreateVehicle () {

		if (CheckVehicleData()) {
			GameObject vehicle = new GameObject ("Vehicle");
			robot = vehicle.gameObject.AddComponent<Robot> ();
			vehicle.AddComponent<SimpleController> ();
			robot.InitializeRobot (vehicleConfig);
		} else {
			Debug.LogWarning ("Vehicle data is missing. Cannot create robot.");
		}


	}

	bool CheckVehicleData () {
		if (vehicleConfig.engineData == null)
			return false;
		if (vehicleConfig.transmissionData == null)
			return false;
		if (vehicleConfig.bodyData == null)
			return false;
		if (vehicleConfig.suspensionData == null)
			return false;
		if (vehicleConfig.wheelData == null)
			return false;
		if (vehicleConfig.brakeData == null)
			return false;
		if (vehicleConfig.boostData == null)
			return false;
		if (vehicleConfig.stabilizerData == null)
			return false;
		if (vehicleConfig.jumpMechanismData == null)
			return false;
		return true;
	}


}
