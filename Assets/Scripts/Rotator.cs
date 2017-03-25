using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float xRotate;
	public float yRotate;
	public float zRotate;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (xRotate, yRotate, zRotate) * Time.deltaTime);
	}
}
