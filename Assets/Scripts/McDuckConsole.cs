using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class McDuckConsole : MonoBehaviour {

	public int Salary;

	public Text SalaryText;

	public ValueObject TargetPrefab;

	public bool TryUsePartial = false;

	// Use this for initialization
	void Start ()
	{
		UpdateSalaryText();
	}

	private void UpdateSalaryText()
	{
		if (!SalaryText)
			return;

		SalaryText.text = string.Format("{0:C}", Salary);
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	public void RaiseSalary(int amount){
		Salary += amount;
		UpdateSalaryText();
	}

	public void ResetSalary()
	{
		Salary = 0;
		UpdateSalaryText();
	}

	public void SetTargetPrefab(ValueObject targetPrefab)
	{
		TargetPrefab = targetPrefab;
	}

	public void MakeItRain()
	{
		int totalElements = Salary / TargetPrefab.Value;
	}

	// Could be float for fractions
	public void SpawnPrefabs(int count)
	{

	}
}
