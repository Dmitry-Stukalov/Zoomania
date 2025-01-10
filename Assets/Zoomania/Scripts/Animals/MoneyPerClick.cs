using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyPerClick : MonoBehaviour, IPointerClickHandler
{
	private int MoneyPerClickValue { get; set; }
	public IncomeResource IncomeMoney { get; private set; }
	private Barn BarnScript { get; set; }
	private Timer SpawnPause { get; set; } = new Timer(0.1f);
	[field: SerializeField] private AudioSource Money { get; set; }


	public event Action OnChange;


	public void Start()
	{
		IncomeMoney = new IncomeResource(0, 0, 5);

		SpawnPause.SetPause();

		BarnScript = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
		BarnScript.Spawn += SpawnPause.Continue;

		SpawnPause.OnTimerEnd += UpdateDataSpawn;
	}

	public void UpdateDataSpawn()										//ќбновл€ет количество получаемых за клик монет
	{

		MoneyPerClickValue = 0;

		BarnScript.Animals[BarnScript.Animals.Count-1].GetComponent<Animals>().LevelUp += UpdateDataSpawn;

		for (int i = 0; i < BarnScript.Animals.Count; i++)
		{
			MoneyPerClickValue += BarnScript.Animals[i].GetComponent<Animals_New>().IncomeMoney.IncomePerClickValue;
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
