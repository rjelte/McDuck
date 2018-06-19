using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Euro : CurrencyObject {
    public float Scale = 0.86f;

	// Use this for initialization
	void Start () {
        FromUSDtoScale = Scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
