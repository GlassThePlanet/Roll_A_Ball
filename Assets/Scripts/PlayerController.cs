using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start(){
		count = 0;
		SetCountText ();
		winText.text = "";
		rb = GetComponent<Rigidbody> ();	
	}

	void Update(){
		
		Vector3 movement = Input.acceleration;

		movement = Quaternion.Euler (90, 0, 0) * movement;
		movement.z = movement.z * speed;
		movement.x = movement.x * speed;
		Debug.Log ("x axis : " + movement.x);
		Debug.Log ("y axis : " + movement.y);
		Debug.Log ("z axis : " + movement.z);
		rb.AddForce (movement);

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
