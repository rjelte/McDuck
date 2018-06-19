using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

public class MoneyChuteController : MonoBehaviour {

    public Money Dollar;
    public int InitialSpawnTimer;
    public int MaxMoneyCount;
    public bool SpawnMoney;
    public bool VacuumMoney;

    private List<Money> Money = new List<Money>();

    private int spawnTimer;
    bool startVacuum;
    float lerpTime = 1f;
    float currentLerpTime;

    // Use this for initialization
    void Start () {
        spawnTimer = InitialSpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (SpawnMoney)
        {
            DropMoney();
        }
        else if (VacuumMoney)
        {
            if (!startVacuum)
            {
                startVacuum = true;
                currentLerpTime = 0f;
            }
            PullUpMoney();
        }

        if (!VacuumMoney)
        {
            startVacuum = false;
        }
    }

    private void PullUpMoney()
    {
        List<Money> moneyToRemove = new List<Money>();
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }
        Money.ForEach(money =>
        {
            float perc = currentLerpTime / lerpTime;
            money.transform.localPosition = Vector3.Lerp(money.transform.localPosition, transform.localPosition, perc);
            money.VacuumMoney = VacuumMoney;
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

    private void DropMoney()
    {
        spawnTimer -= 1;

        if (spawnTimer <= 0 && Money.Count < MaxMoneyCount)
        {
            spawnTimer = InitialSpawnTimer;

            Money gem = ResetMoney();
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

        if(Money.Count >= MaxMoneyCount)
        {
            SpawnMoney = false;
        }
    }

    private Money ResetMoney()
    {
        Money money = null;
		money = Instantiate(Dollar);
        money.transform.parent = transform;
        money.transform.localPosition = new Vector3(0, -0.3f, 0);
        money.IsAlive = true;
        return money;
    }
}
