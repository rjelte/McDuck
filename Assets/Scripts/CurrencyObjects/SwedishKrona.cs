using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwedishKrona : CurrencyObject {
    public float Scale = 8.79f;

	// Use this for initialization
	void Start () {
        FromUSDtoScale = Scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
