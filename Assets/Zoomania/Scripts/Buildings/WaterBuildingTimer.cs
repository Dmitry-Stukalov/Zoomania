using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

//Устаревшее
public class WaterBuildingTimer : MonoBehaviour
{
	[field: SerializeField] private ImprovementLevelsConfig _levelsConfig { get; set; }
	[field: SerializeField] public ParticleSystem Click { get; set; }
	[field: SerializeField] public AudioSource Audio { get; set; }
	public ImprovementLevel CurrentLevel { get; set; }
	public IncomeResource IncomeResources { get; set; }
	private WaterBuildingValue WaterBuildingV {  get; set; }
	private bool IsLoadData { get; set; } = false;


	public event Action OnChange;
	public event Action OnUpgrade;
	public event Action OnStart;

	public void Initializing()
	{
		if (!IsLoadData) CurrentLevel = _levelsConfig.levels[0];

		WaterBuildingV = GetComponent<WaterBuildingValue>();
		WaterBuildingV.OnUpgrade += UpdateData;

		IncomeResources = new IncomeResource(WaterBuildingV.GetCurrentResourceValue(), CurrentLevel.EffectValue);
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
		IsLoadData = true;

		CurrentLevel = _levelsConfig.levels[CurrentLevel.CurrentLevelNumber];

		IncomeResources.ChangeTime(CurrentLevel.EffectValue);

		OnUpgrade?.Invoke();

	}

	public void UpdateData()
	{
		IncomeResources.ChangeIncomeValue(WaterBuildingV.CurrentLevelData().IncomePerSecondValue);
	}

	public ImprovementLevel CurrentLevelData()
	{
		return CurrentLevel;
	}

	public ImprovementLevel NextLevelData()
	{
		if (CurrentLevel.CurrentLevelNumber <= _levelsConfig.levels.Count - 1) return _levelsConfig.levels[CurrentLevel.CurrentLevelNumber];
		else return null;
	}

	public int GetLevelsCount()
	{
		return _levelsConfig.levels.Count;
	}

	public async Task LoadData(float value, int levelnumber)
	{
		IncomeResources.CurrentResourceCount = value;
		CurrentLevel = _levelsConfig.levels[levelnumber - 1];
		UpdateData();
		OnChange?.Invoke();
		//OnStart?.Invoke();
	}

	void Update()                                                                                   //Срабатывает каждый кадр, отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
