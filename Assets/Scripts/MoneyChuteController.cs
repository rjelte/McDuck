using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

public class MoneyChuteController : MonoBehaviour {

    public Money Dollar;
    public int InitialSpawnTimer;
    public int MaxMoneyCount;

    private List<Money> Money = new List<Money>();

    private int spawnTimer;

    // Use this for initialization
    void Start () {
        spawnTimer = InitialSpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= 1;

        if (spawnTimer == 0 && Money.Count < MaxMoneyCount)
        {
            spawnTimer = InitialSpawnTimer;

            Money gem = ResetMoney(MoneyTypes.Dollars);
            Money.Add(gem);
        }

        List<Money> moneyToRemove = new List<Money>();

        Money.ForEach(money =>
        {
            money.UpdateMoney();
            if (!money.IsAlive)
            {
                moneyToRemove.Add(money);
            }
        });

        foreach (var p in moneyToRemove)
        {
            Money.Remove(p);
            Destroy(p.gameObject);
        }
    }

    private Money ResetMoney(string moneyType)
    {
        Money money = null;
        switch (moneyType)
        {
            case MoneyTypes.Dollars:
                money = Instantiate(Dollar);
                break;
        }
        money.transform.parent = transform;
        money.transform.localPosition = new Vector3(0, -0.3f, 0);
        money.IsAlive = true;
        return money;
    }
}
