using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject : MonoBehaviour 
{
	public int Value;

	public string Name;

	public float ConversionFromUSD;

	public Money Money;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float GetUSDValue()
	{
		return Value * ConversionFromUSD;
	}
}
