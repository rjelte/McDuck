using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour {

    private bool onGround = false;
    Rigidbody rBody;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(8)) {
            onGround = true;
        }

        if (onGround) {
            DisableRagdoll();
            transform.parent = collision.gameObject.transform;
            gameObject.layer = 8;
        }
    }

    void EnableRagdoll()
    {
        rBody.isKinematic = false;
        rBody.detectCollisions = true;
    }
    void DisableRagdoll()
    {
        rBody.isKinematic = true;
        rBody.detectCollisions = false;
    }
}
