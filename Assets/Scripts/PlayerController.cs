using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public Text countText;
	public Text winText;

	public Vector3 MoveVector{ set; get; }
	public Camera gameCamera;
	private Transform cameraTransform;
	private Rigidbody rb;
	private int count;

	void Start(){
		count = 0;
		SetCountText ();
		winText.text = "";
		rb = GetComponent<Rigidbody> ();	
		rb.maxAngularVelocity = terminalRotationSpeed;
		rb.drag = drag;
	}

	void Update(){

		MoveVector = PoolInput ();
		MoveVector = RotateWithView ();
		Move ();
	}

	private Vector3 PoolInput(){
		Vector3 direction = Vector3.zero;

		direction.z = Input.GetAxis ("Vertical");

		if (direction.magnitude > 1) {
			direction.Normalize();
		}

		return direction;

	}

	private void Move(){
		/**
		 * for phone controller
		 * Vector3 movement = Input.acceleration;
		 * movement = Quaternion.Euler (90, 0, 0) * movement;
		 * movement.z = movement.z * speed * Time.deltaTime;
		 * movement.x = movement.x * speed * Time.deltaTime;
		 * rb.AddForce (movement);
		 */

		rb.AddForce((MoveVector * movementSpeed));
	}

	private Vector3 RotateWithView(){

		if (cameraTransform != null) {
			Debug.Log ("cameraTransform not null");
			Vector3 direction = cameraTransform.TransformDirection (MoveVector);
			direction.Set (direction.x, 0, direction.z);
			return direction.normalized * MoveVector.magnitude;
		} else {
			Debug.Log ("cameraTransform null");
			cameraTransform = gameCamera.transform;
			return MoveVector;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) {
			winText.text = "You Winner";
		}
	}
}
