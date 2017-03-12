using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_pub : MonoBehaviour {

	public int Rotate;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 1, 0) * Rotate);

	}
}
