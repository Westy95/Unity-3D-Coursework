using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Allows for manual input of player speed
	public float speed;

	//Place holders to allow connection to other objects
	public Transform SpawnPoint;
	public GameObject player;
	public Transform respawnPoint;

	private Rigidbody rb;

	//Flags to control state of game
	private float elapsedTime = 0;
	private bool isRunning = false;
	private bool isFinished = false;

	void Start (){
		rb = GetComponent<Rigidbody>();

	}

	private void StartGame(){
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;
		player.transform.position = SpawnPoint.position;
	}

	void FixedUpdate (){
		if (isRunning) {
			elapsedTime += Time.deltaTime;
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Finish")) {
			other.gameObject.SetActive (false);
			FinishedGame ();
			other.gameObject.transform.position = respawnPoint.position;

		}
	}

	public void FinishedGame (){
		isRunning = false;
		isFinished = true;
	}


	//This section creates the Graphical User Interface (GUI)
	void OnGUI() {

		if(!isRunning) {
			string message;

			if(isFinished) {
				message = "Click to Play Again";
			} else {
				message = "Click to Play";
			}

			Rect startButton = new Rect(Screen.width/2 - 70, Screen.height/2, 140, 30);
			if(GUI.Button(startButton, message)) {
				//start the game if the user clicks to play
				StartGame ();
			}
		}

		// If the player finished the game, show the final time
		if(isFinished) {
			GUI.Box(new Rect(Screen.width / 2 - 130, 185, 130, 40), "Your Time Was");
			GUI.Label(new Rect(Screen.width / 2 - 20, 200, 20, 30), ((int)elapsedTime).ToString());
		} else if(isRunning) { // If the game is running, show the current time
			GUI.Box(new Rect(Screen.width / 2 - 130, Screen.height - 115, 130, 40), "Your Time Is");
			GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
		}

	}
}
