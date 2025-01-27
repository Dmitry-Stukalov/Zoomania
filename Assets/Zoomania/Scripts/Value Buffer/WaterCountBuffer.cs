using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCountBuffer : MonoBehaviour
{
	[field: SerializeField] public ResourceBuilding WaterBuildingScript { get; set; }
	public int WaterCount { get; set; }


	public event Action OnChange;


	public void Start()
	{
		WaterCount = 0;

		WaterBuildingScript.OnChange += UpdateData;
	}

	public void UpdateData()
	{
		WaterCount = WaterBuildingScript.IncomeResources.Resource;
		OnChange?.Invoke();
	}

	public int GetWaterCount()
	{
		return WaterCount;
	}
}