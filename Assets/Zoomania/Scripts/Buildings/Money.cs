using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Money : MonoBehaviour, IResourceStorage
{
	public ResourceType ResourceType { get; private set; }
	public IncomeResource IncomeResources { get; private set; }

	public event Action OnChange;



	public void Start()
	{
		IncomeResources = new IncomeResource(0, 0);
	}

	public void SetMoneyValue(float value)
	{
		IncomeResources.CurrentResourceCount -= value;
		OnChange?.Invoke();
	}

	public void IncreaseMoneyValue(float value)
	{
		IncomeResources.CurrentResourceCount += value;
		OnChange?.Invoke();
	}

	public float GetMoney()
	{
		return IncomeResources.CurrentResourceCount;
	}

	public async Task LoadData(float value)
	{
		IncomeResources.CurrentResourceCount = value;
		OnChange?.Invoke();
	}

	public void InvokeChanges()
	{
		OnChange?.Invoke();
	}
}
