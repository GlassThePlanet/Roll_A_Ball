using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float angularSpeed;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}


	void LateUpdate () {
		
		transform.position = player.transform.position + offset;
		float movement = Input.GetAxis ("Horizontal") * angularSpeed * Time.deltaTime;
		if (!Mathf.Approximately (movement, 0f)) {
			transform.RotateAround (player.transform.position, Vector3.up, movement);
			offset = transform.position - player.transform.position;
		}
	}


}
