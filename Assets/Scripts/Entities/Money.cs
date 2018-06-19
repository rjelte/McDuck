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

    private Vector2 basePosition;
    private float bounce;
    private Vector2 velocity;

    // Use this for initialization
    void Start () {
        basePosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool CheckIfFell()
    {
        return transform.localPosition.y > 3 || transform.localPosition.y < -200;
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
    }
}
