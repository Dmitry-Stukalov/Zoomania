using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCountBuffer : MonoBehaviour
{
	[field: SerializeField] public ResourceBuilding FoodBuildingScript { get; set; }
	public int FoodCount { get; set; }


	public event Action OnChange;


	public void Start()
	{
		FoodCount = 0;

		FoodBuildingScript.OnChange += UpdateData;
	}

	public void UpdateData()
	{
		FoodCount = FoodBuildingScript.IncomeResources.Resource;
		OnChange?.Invoke();
	}

	public int GetFoodCount()
	{
		return FoodCount;
	}
}