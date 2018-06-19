using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour {

    Collider m_collider;
    Rigidbody m_rigidbody;

    void Start()
    {
        m_collider = GetComponent<Collider>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer.Equals(8) && !gameObject.tag.Equals("childMoney"))
        {
            gameObject.tag = "parentMoney";
        }
        if (collision.gameObject.tag.Equals("parentMoney") && gameObject.tag.Equals("money"))
        {
            m_collider.enabled = false;
            m_rigidbody.isKinematic = true;
            gameObject.transform.parent = collision.gameObject.transform;
            gameObject.tag = "childMoney";
        }
        else if (collision.gameObject.tag.Equals("childMoney") && gameObject.tag.Equals("money"))
        {
            m_collider.enabled = false;
            m_rigidbody.isKinematic = true;
            gameObject.transform.parent = collision.gameObject.transform.root;
            gameObject.tag = "childMoney"; 
        }
    }
}
