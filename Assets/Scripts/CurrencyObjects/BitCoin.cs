using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitCoin : CurrencyObject
{
    public float Scale = 0.00015f;
	// Use this for initialization
	void Start () {
        FromUSDtoScale = Scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
