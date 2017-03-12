using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	public PlayerController playerController;

	void OnTriggerEnter (Collider other){
		playerController.FinishedGame();
	}
}
