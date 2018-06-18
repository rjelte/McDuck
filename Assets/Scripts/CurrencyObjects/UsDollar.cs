using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsDollar : CurrencyObject {
    public float Scale = 1f;
    private List<double> listofValues;
    private Dictionary<double, string> denomations;


    public UsDollar()
    {
        FromUSDtoScale = Scale;
        listofValues = new List<double>() { .01, .05, .1, 0.25, 1, 5, 10, 20, 50, 100 };
        denomations = new Dictionary<double, string>
        {
            { .01, "Pennies"},
            { .05, "Nickels" },
            {  0.1, "Dimes" },
            {  0.25, "Quarter" },
            {  1, "One Dollar Bill" },
            {  5, "Five Dollar Bill" },
            {  10, "Ten Dollar Bill"},
            {  20, "Twenty Dollar Bill" },
            {  50, "Fifty Dollar Bill" },
            {  100, "One Hundred Dollar Bill" }
        };
    }
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Dictionary<string, int> ConvertToDenominations(double amount, double startingDenomination)
    {
        if (!listofValues.Contains(startingDenomination))
        {
            throw new KeyNotFoundException("Denomination was not found in list of Currency. Please use valid denomination");
        }

        if(amount <= 0)
        {
            throw new System.Exception("Amount is invalid. Please enter a valid amount");
        }
        var index = listofValues.IndexOf(startingDenomination);
        return CalculateCurrencyDenominations(amount, index, new Dictionary<string, int>());
    }

    private Dictionary<string, int> CalculateCurrencyDenominations(double amount, int index, Dictionary<string, int> divisions)
    {
        var count = 0;

        if (index == 0)
        {
            count = (int)(amount / listofValues[index]);
            divisions.Add(denomations[listofValues[index]], count);
            return divisions;
        }

        if (amount < listofValues[index])
        {
            return CalculateCurrencyDenominations(amount, index - 1, divisions);
        }

        count = (int)(amount / listofValues[index]);
        divisions.Add(denomations[listofValues[index]], count);
        var difference = amount - (count * listofValues[index]);

        if(difference == 0)
        {
            return divisions;
        }

        return CalculateCurrencyDenominations(difference, index - 1, divisions);
    }
}
