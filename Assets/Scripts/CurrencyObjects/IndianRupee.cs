using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianRupee : CurrencyObject {

    public float Scale = 68.16f;
	// Use this for initialization
	void Start () {
        FromUSDtoScale = Scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
