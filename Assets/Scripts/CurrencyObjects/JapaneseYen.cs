using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapaneseYen : CurrencyObject {
    public float Scale = 110.86f;

	// Use this for initialization
	void Start () {
        FromUSDtoScale = Scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
