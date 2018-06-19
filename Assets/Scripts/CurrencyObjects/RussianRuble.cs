using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianRuble : CurrencyObject {

    public float Scale = 63.16f;
	// Use this for initialization
	void Start () {
        FromUSDtoScale = Scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
