using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

//Устаревшее
public class WaterBuildingValue : MonoBehaviour
{
	[field: SerializeField] private BuildingLevelsConfig levels_config { get; set; }
	public BuildingLevel CurrentLevel { get; set; }
	private bool IsLoadData { get; set; } = false;
	private SpriteRenderer sprite;

	public event Action OnChange;
	public event Action OnUpgrade;
	public event Action OnStart;

	public void Initializing()
	{
		sprite = GetComponent<SpriteRenderer>();

		if (!IsLoadData)
		{
			CurrentLevel = levels_config.levels[0];
			sprite.sprite = CurrentLevel.View;
			OnStart?.Invoke();
		}

	}

	public void Change()
	{
		OnChange?.Invoke();
	}

	public void Upgrade()
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		sprite.sprite = CurrentLevel.View;

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
		IsLoadData = true;

		CurrentLevel = levels_config.levels[levelnumber - 1];
		sprite.sprite = CurrentLevel.View;

		OnChange?.Invoke();
		OnStart?.Invoke();
	}
}
