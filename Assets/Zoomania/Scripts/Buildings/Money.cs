using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Money : MonoBehaviour
{
	public IncomeResource IncomeMoney { get; set; }


	public event Action OnChange;


	public void Start()
	{
		IncomeMoney = new IncomeResource(0, 0, 5);
	}

	public void SetMoneyValue(int value)
	{
		IncomeMoney.Resource -= value;
		OnChange?.Invoke();
	}

	public void IncreaseMoneyValue(int value)
	{
		IncomeMoney.Resource += value;
		OnChange?.Invoke();
	}

	public void InvokeChanges()
	{
		OnChange?.Invoke();
	}
}
