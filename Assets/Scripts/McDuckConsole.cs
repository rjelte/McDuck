using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class McDuckConsole : MonoBehaviour {

	public int Salary;

	public Text SalaryText;
	public Text CurrencyText;

	public ValueObject TargetPrefab;

	public MoneyChuteController ChuteController;

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
		ChuteController.Dollar = TargetPrefab.Money;
		UpdateCurrencyText();
	}

	private void UpdateCurrencyText()
	{
		CurrencyText.text = string.Format("{0} {1}s",TargetPrefab.Value, TargetPrefab.Name);
	}

	public void MakeItRain()
	{
		int totalElements = Salary / TargetPrefab.Value;
		ChuteController.MaxMoneyCount = totalElements;
		ChuteController.SpawnMoney = true;
		ChuteController.InitialSpawnTimer = 5;
	}
}
