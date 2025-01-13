using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals_New : MonoBehaviour
{
	public Panda_Levels_Config levels_config;

	public IncomeResource IncomeMoney { get; private set; }
	public AnimalLevel CurrentLevel { get; private set; }
	public MoneyPerClick moneyperclick { get; private set; }
	private GameObject Barn { get; set; }
	public bool InPersonalPaddock { get; private set; } = true;

	public AudioSource SoundLevelUp;
	public AudioSource SoundSpawn;

	public event Action LevelUp;
	public event Action ChangePaddock;

	private int TimerForGetMoney = 5;


	public void Start()
	{

		CurrentLevel = levels_config.levels[0];

		Barn = GameObject.FindGameObjectWithTag("Barn");

		ChangeParent(Barn, true);

		IncomeMoney = new IncomeResource(CurrentLevel.MoneyPerSecond, CurrentLevel.MoneyPerClick, TimerForGetMoney);

		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		SoundSpawn.Play();
	}

	public void Upgrade()                                                                   //Повышение уровня панды
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

		IncomeMoney.IncomePerSecondValue = CurrentLevel.MoneyPerSecond;
		IncomeMoney.IncomePerClickValue = CurrentLevel.MoneyPerClick;

		SoundLevelUp.Play();

		LevelUp?.Invoke();
	}

	public void ChangeParent(GameObject newparent, bool flag)
	{
		this.transform.SetParent(newparent.transform, flag);

		if (InPersonalPaddock) InPersonalPaddock = false;
		else InPersonalPaddock = true;

		ChangePaddock?.Invoke();
	}
}
