using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {
	Animator animatorController;

	bool walk = false;
	public float speed = 6f;
	Vector3 movement;     
	Rigidbody playerRigidbody;    
	// Use this for initialization
	void Start () {
		animatorController = GetComponent<Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
//			this.transform.Rotate (0, 90, 0);
			animatorController.SetBool ("turnRight", true);
			walk = false;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
//			this.transform.Rotate (0, -90, 0);

			animatorController.SetBool ("turnLeft", true);
			walk = false;
		}
		if (Input.GetKey (KeyCode.W)) {
			animatorController.SetBool ("walk", true);
			walk = true;
		}
		if (Input.GetKey (KeyCode.S)) {
//			this.transform.Rotate (0, 180, 0);

			animatorController.SetBool ("turn180", true);
			walk = false;

		}
		if (!Input.GetKey(KeyCode.W)) {
			animatorController.SetBool ("walk", false);
			walk = false;
		}
		if (!Input.GetKeyDown (KeyCode.D)) {
			animatorController.SetBool ("turnRight", false);
		}
		if (!Input.GetKey (KeyCode.A) ) {
			animatorController.SetBool ("turnLeft", false);
		}
		if (!Input.GetKey (KeyCode.S)) {
			animatorController.SetBool ("turn180", false);
		}
//		float y = this.transform.eulerAngles.y;
//		Debug.Log ("y " + y);
//
		if (walk) {
			MoveNow ();
		}
	}
	void MoveNow ()
	{
		float y = this.transform.eulerAngles.y;

		float x = Mathf.Sin (Mathf.Deg2Rad * y);
		Debug.Log ("y " + y);
		Debug.Log (x);
//		x = Mathf.Deg2Rad *x;
//		if (x < 0.5 && x > 0) {
//			x = 0;
//		} else {
//			if (x >= 0.5) {
//				x = 1;
//			} else {
//				if (x < -0.5) {
//					x = -1;
//				} else {
//					x = 0;
//				}
//			}
//		}
		float z = Mathf.Cos (Mathf.Deg2Rad * y);
//		if (z < 0.5 && z > 0) {
//			z = 0;
//		} else {
//			if (z >= 0.5) {
//				z = 1;
//			} else {
//				if (z < -0.5) {
//					z = -1;
//				} else {
//					z = 0;
//				}
//			}
//		}
//		z = Mathf.Deg2Rad *z;
		Debug.Log ("x " + x);
		Debug.Log ("z " + z);
		Move (x, z);
//		float x = 0; 
//		float z  = 0;
//		y = y * -1f + 360 + 90;
////		Debug.Log (y + 90);
////		if (y < 90) {
////			y = 0;
////		}
////		while (y >= 360) {
////			y -= 360;
////		}
////		if (y <= 90 && y >= 0) {
////			y = 90;
////		}
////		if (y <= 180 && y > 90) {
////			y = 180;
////		}
////		if (y < 360 && y >= 270) {
////			y = 270;
////		}
//		float x =  Mathf.Cos (y);
//		float z =  Mathf.Sin (y);
////		}
//		// Store the input axes.
//		Debug.Log ("x " + x);
//		Debug.Log ("y " + y);
//		Debug.Log ("z " + z);
//
//		// Move the player around the scene.
//		Move (x, z);

		// Turn the player to face the mouse cursor.
	}
	void Move (float x, float z)
	{
//		this.transform.position = new Vector3 (this.transform.position.x + x, this.transform.position.y, this.transform.position.z + z);
		// Set the movement vector based on the axis input.
		movement.Set (x, 0f, z);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}
}
