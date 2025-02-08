using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Bamboo : MonoBehaviour																	//Поменять эффект после покупки
{
	[field: SerializeField] private Improvement_Levels_Config improvement_levels_config { get; set; }
	private Money Money {  get; set; }
	public Improvement_Level CurrentLevel { get; private set; }
	private List<GameObject> Bamboo { get; set; }

	public event Action OnUpgrade;
	private Timer GetMoney {  get; set; }


	public void Start()
	{
		Money = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		GetMoney = new Timer(3);

		GetMoney.OnTimerEnd += GetSomeMoney;

		CurrentLevel = improvement_levels_config.levels[0];

		Bamboo = new List<GameObject>();

		foreach (var bamboo in GameObject.FindGameObjectsWithTag("Bamboo"))
		{
			Bamboo.Add(bamboo);
			bamboo.SetActive(false);
		}
	}

	public void Upgrade()
	{
		CurrentLevel = improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];

		Bamboo[CurrentLevel.CurrentLevelNumber-1].SetActive(true);

		OnUpgrade?.Invoke();
	}

	public Improvement_Level NextLevelData()
	{
		return improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];
	}

	public void GetSomeMoney()
	{
		Money.IncreaseMoneyValue(CurrentLevel.EffectValue);
		GetMoney.ResetTimer(false);
	}

	public void Update()
	{
		if (CurrentLevel.CurrentLevelNumber > 0) 
		{
			GetMoney.Tick(Time.deltaTime);
		}
	}
}