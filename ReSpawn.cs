using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour {

	//Place holder for the spawn point
	public Transform respawnPoint;

	//Triggers when player enters hole
	void OnTriggerEnter (Collider other){
		other.gameObject.transform.position = respawnPoint.position;
	}
}
