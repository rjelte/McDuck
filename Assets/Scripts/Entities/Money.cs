using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public bool IsAlive;
    public bool IsOnGround;
    public bool VacuumMoney;

    private const float GravityAcceleration = 3400.0f;
    private const float MaxFallSpeed = 550.0f;
    private Collider m_collider;
    private Rigidbody m_rigidbody;
    private Vector2 basePosition;
    private float bounce;
    private Vector2 velocity;

    // Use this for initialization
    void Start () {
        basePosition = transform.localPosition;
        m_collider = GetComponent<Collider>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private bool CheckIfFell()
    {
        return transform.localPosition.y > 3 || transform.localPosition.y < -200
            || (VacuumMoney && transform.localPosition == new Vector3(0, -0.3f, 0));
    }
    
    public void UpdateMoney()
    {
        if (CheckIfFell() && IsAlive)
        {
            IsAlive = false;
        }

        if (IsAlive)
        {
            
        }
    }

    public void Reset(Vector3 resetPosition)
    {
        IsAlive = true;
        IsOnGround = false;
        transform.localPosition = resetPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            IsOnGround = true;
        }else if(collision.gameObject.tag == "MoneyChute" && VacuumMoney)
        {
            IsAlive = false;
        }

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
