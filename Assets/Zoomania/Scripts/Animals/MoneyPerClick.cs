using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyPerClick : MonoBehaviour, IPointerClickHandler
{
	public int MoneyPerClickValue;

	public IncomeResource IncomeMoney = new IncomeResource(0, 0, 5);

	public Barn BarnScript;

	public Timer SpawnPause = new Timer(0.1f);

	public AudioSource Money;



	public event Action OnChange;


	public void Start()
	{
		SpawnPause.SetPause();
		BarnScript = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
		BarnScript.Spawn += SpawnPause.Continue;
		SpawnPause.OnTimerEnd += UpdateDataSpawn;
	}

	public void UpdateDataSpawn()
	{

		MoneyPerClickValue = 0;

		BarnScript.Animals[BarnScript.Animals.Count-1].GetComponent<Animals>().LevelUp += UpdateDataSpawn;

		for (int i = 0; i < BarnScript.Animals.Count; i++)
		{
			if (BarnScript.Animals[i].GetComponent<Animals>().Hungry) MoneyPerClickValue += 0;
			else MoneyPerClickValue += BarnScript.Animals[i].GetComponent<Animals>().IncomeMoney.IncomePerClickValue;
		}

		 
		IncomeMoney.IncomePerClickValue = MoneyPerClickValue;

		SpawnPause.ResetTimer(true);

		OnChange?.Invoke();
	}

	public void UpdateDataPerSecond(int value)
	{
		IncomeMoney.Resource += value;
		OnChange?.Invoke();
	}

	public void IncomePerClick()
	{
		IncomeMoney.IncomePerClick();
		OnChange?.Invoke();
	}

	public void OnPointerClick(PointerEventData data)
	{
		IncomePerClick();
		Money.Play();
	}

	public void SetMoneyValue(int value)
	{
		IncomeMoney.Resource -= value;
	}

	public void Update()
	{
		SpawnPause.Tick(Time.deltaTime);
	}
}
