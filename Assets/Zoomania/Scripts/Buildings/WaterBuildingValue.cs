using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaterBuildingValue : MonoBehaviour
{
	[field: SerializeField] private Building_Levels_Config levels_config { get; set; }
	public BuildingLevel CurrentLevel { get; set; }


	public event Action OnChange;
	public event Action OnUpgrade;
	public event Action OnStart;

	private void Start()
	{
		CurrentLevel = levels_config.levels[0];

		OnStart?.Invoke();
	}

	public void Change()
	{
		OnChange?.Invoke();
	}

	public void Upgrade()
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		
		OnUpgrade?.Invoke();
	}

	public int DragResourceValue()
	{
		return CurrentLevel.DragResourceCapacity;
	}

	public int GetCurrentResourceValue()
	{
		return CurrentLevel.IncomePerSecondValue;
	}

	public BuildingLevel CurrentLevelData()
	{
		return CurrentLevel;
	}

	public BuildingLevel NextLevelData()
	{
		if (CurrentLevel.CurrentLevelNumber <= levels_config.levels.Count - 1) return levels_config.levels[CurrentLevel.CurrentLevelNumber];
		else return null;
	}

	public int GetLevelsCount()
	{
		return levels_config.levels.Count;
	}

	public async Task LoadData(int levelnumber)
	{
		CurrentLevel = levels_config.levels[levelnumber - 1];
		OnChange?.Invoke();
	}
}
