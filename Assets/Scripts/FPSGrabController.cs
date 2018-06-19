using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a super fast.hacky way to replicate the VR grab functionality on a FPS controller.
/// </summary>
public class FPSGrabController : MonoBehaviour
{
	private GameObject collidingObject;
	private GameObject objectInHand;
	private Rigidbody fakeHand;

	// Use this for initialization
	void Start () {
		fakeHand = GetComponent<Rigidbody>();
	}

	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

	public void OnCollisionEnter(Collision collision)
	{
		SetCollidingObject(collision.collider);
	}

	public void OnCollisionStay(Collision collision)
	{
		SetCollidingObject(collision.collider);
	}

	public void OnCollisionExit(Collision collision)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

	private void SetCollidingObject(Collider col)
	{
		if (collidingObject || !col.GetComponent<Rigidbody>() || objectInHand)
		{
			return;
		}

		collidingObject = col.gameObject;
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			if (collidingObject)
			{
				GrabObject();
			}
		}else{
			if (objectInHand)
			{
				ReleaseObject();
			}
		}
	}

	private void GrabObject()
	{
		objectInHand = collidingObject;
		collidingObject = null;
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}

	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject()
	{
		if (GetComponent<FixedJoint>())
		{
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());
			objectInHand.GetComponent<Rigidbody>().velocity = fakeHand.velocity;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = fakeHand.angularVelocity;
		}

		objectInHand = null;
	}

}
