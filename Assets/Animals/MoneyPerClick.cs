using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyPerClick : MonoBehaviour, IPointerClickHandler
{
	public IntStorage MoneyPerClickValue = new IntStorage();

	public IncomeResource IncomeMoney = new IncomeResource(0, 0);

	public GameObject Barn;

	public Barn BarnScript;

	public Timer SpawnPause = new Timer(0.1f);



	public event Action OnChange;


	public void Start()
	{
		SpawnPause.SetPause();
		Barn = GameObject.Find("Àלבאנ");
		BarnScript = Barn.GetComponent<Barn>();
		BarnScript.Spawn += SpawnPause.Continue;
		SpawnPause.OnTimerEnd += UpdateDataSpawn;
	}

	public void UpdateDataSpawn()
	{

		MoneyPerClickValue.ChangeValue(0);

		BarnScript.Animals[BarnScript.Animals.Count-1].GetComponent<Animals>().LevelUp += UpdateDataSpawn;

		for (int i = 0; i < BarnScript.Animals.Count; i++)
		{
			if (BarnScript.Animals[i].GetComponent<Animals>().Hungry) MoneyPerClickValue.SetValue(0, true);
			else MoneyPerClickValue.SetValue(BarnScript.Animals[i].GetComponent<Animals>().IncomeMoney.IncomePerClickValue, true);
		}


		IncomeMoney.IncomePerClickValue = MoneyPerClickValue.GetValue();

		SpawnPause.ResetTimer(true);

		OnChange?.Invoke();
	}

	public void UpdateDataPerSecond(int value)
	{
		IncomeMoney.Resource.SetValue(value, true);
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
	}

	public void SetMoneyValue(int value)
	{
		IncomeMoney.Resource.SetValue(value, false);
	}

	public void Update()
	{
		SpawnPause.Tick(Time.deltaTime);
	}
}
