using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

//Устаревшее
public class FoodBuildingTimer : MonoBehaviour
{
	[field: SerializeField] private ImprovementLevelsConfig levels_config { get; set; }
	[field: SerializeField] public ParticleSystem Click { get; set; }
	[field: SerializeField] public AudioSource Audio { get; set; }
	public ImprovementLevel CurrentLevel { get; set; }
	public IncomeResource IncomeResources { get; set; }
	private FoodBuildingValue FoodBuildingV { get; set; }
	private bool IsLoadData { get; set; } = false;

	public event Action OnChange;
	public event Action OnUpgrade;
	public event Action OnStart;

	public void Initializing()
	{
		if (!IsLoadData) CurrentLevel = levels_config.levels[0];

		FoodBuildingV = GetComponent<FoodBuildingValue>();
		FoodBuildingV.OnUpgrade += UpdateData;

		IncomeResources = new IncomeResource(FoodBuildingV.GetCurrentResourceValue(), CurrentLevel.EffectValue);
		IncomeResources.ResourceTimer.OnTimerEnd += Effects;
	}

	public void Change()
	{
		OnChange?.Invoke();
	}

	private void Effects()
	{
		Click.Play();
		Audio.Play();

		OnChange?.Invoke();
	}

	public void AddResources(int value)
	{
		IncomeResources.CurrentResourceCount += value;

		OnChange?.Invoke();
	}

	public float GetResources()
	{
		return IncomeResources.CurrentResourceCount;
	}

	public void Upgrade()
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];

		IncomeResources.ChangeTime(CurrentLevel.EffectValue);

		OnUpgrade?.Invoke();

	}

	public void UpdateData()
	{
		IncomeResources.ChangeIncomeValue(FoodBuildingV.CurrentLevelData().IncomePerSecondValue);
	}

	public ImprovementLevel CurrentLevelData()
	{
		return CurrentLevel;
	}

	public ImprovementLevel NextLevelData()
	{
		if (CurrentLevel.CurrentLevelNumber <= levels_config.levels.Count - 1) return levels_config.levels[CurrentLevel.CurrentLevelNumber];
		else return null;
	}

	public int GetLevelsCount()
	{
		return levels_config.levels.Count;
	}

	public async Task LoadData(float value, int levelnumber)
	{
		IsLoadData = true;

		IncomeResources.CurrentResourceCount = value;
		CurrentLevel = levels_config.levels[levelnumber - 1];
		UpdateData();
		OnChange?.Invoke(); 
	}

	void Update()                                                                                   //Срабатывает каждый кадр, отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
