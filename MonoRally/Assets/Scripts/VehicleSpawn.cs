using UnityEngine;
using System.Collections;

[AddComponentMenu("MonoRally/Vehicle Spawn")]
public class VehicleSpawn : MonoBehaviour {

	void Awake () {
		RaceManager.instance.AddSpawnPoint (this);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos () {
		Gizmos.DrawIcon (transform.position, "VehicleSpawnIcon.png", true);
	}
}
