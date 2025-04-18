using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FoodBuildingTimer : MonoBehaviour
{
	[field: SerializeField] private Improvement_Levels_Config_New levels_config { get; set; }
	[field: SerializeField] public ParticleSystem Click { get; set; }
	[field: SerializeField] public AudioSource Audio { get; set; }
	public Improvement_Level_New CurrentLevel { get; set; }
	public IncomeResource IncomeResources { get; set; }
	private FoodBuildingValue FoodBuildingV { get; set; }


	public event Action OnChange;
	public event Action OnUpgrade;
	public event Action OnStart;

	private void Start()
	{
		CurrentLevel = levels_config.levels[0];

		FoodBuildingV = GetComponent<FoodBuildingValue>();

		if (Input.touchSupported)
		{
			Initialize();
		}
		else if (Input.mousePresent)
		{
			FoodBuildingV.OnStart += Initialize;
		}

		FoodBuildingV.OnUpgrade += UpdateData;
	}

	private void Initialize()
	{
		IncomeResources = new IncomeResource(FoodBuildingV.GetCurrentResourceValue(), CurrentLevel.EffectValue);
		IncomeResources.ResourceTimer.OnTimerEnd += Effects;
		OnStart?.Invoke();
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
		IncomeResources.Resource += value;

		OnChange?.Invoke();
	}

	public float GetResources()
	{
		return IncomeResources.Resource;
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

	public Improvement_Level_New CurrentLevelData()
	{
		return CurrentLevel;
	}

	public Improvement_Level_New NextLevelData()
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
		IncomeResources.Resource = value;
		CurrentLevel = levels_config.levels[levelnumber - 1];
		OnChange?.Invoke();
	}

	void Update()                                                                                   //Срабатывает каждый кадр, отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
