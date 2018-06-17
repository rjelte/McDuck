using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFall : MonoBehaviour {
	private Rigidbody   rigidBody;
	bool grounded = false;
	public Transform groundCheck;
	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1<< LayerMask.NameToLayer("Ground"));
		var dir = this.rigidBody.velocity;
		Debug.Log(string.Format("Velocity: {0}", dir.magnitude));
 		if ((dir != Vector3.zero)) {
 			transform.rotation = Quaternion.LookRotation(dir);
		}
	}
}
