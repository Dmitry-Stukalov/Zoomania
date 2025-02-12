using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceBuilding : MonoBehaviour
{
	[field: SerializeField] private Building_Levels_Config levels_config { get; set; }
	[field: SerializeField] private Improvement_Levels_Config_New improvement_levels_config { get; set; }
	[field: SerializeField] public ParticleSystem Click { get; set; }
	[field: SerializeField] public AudioSource Audio { get; set; }
	public BuildingLevel CurrentLevel { get; set; }
	public Improvement_Level_New CurrentImproveLevel { get; set; }
	public IncomeResource IncomeResources { get; set; }
	public int TimeLevelNumber { get; set; }
	private int TimeDifference { get; set; }
	private int ValueDifference { get; set; }


	public event Action OnChange;
	public event Action OnUpgrade;


	private void Start()
	{
		CurrentLevel = levels_config.levels[0];
		CurrentImproveLevel = improvement_levels_config.levels[0];

		IncomeResources = new IncomeResource(CurrentLevel.IncomePerSecondValue, CurrentImproveLevel.EffectValue);
		IncomeResources.ResourceTimer.OnTimerEnd += Effects;

		TimeLevelNumber = 1;
		TimeDifference = 0;
		ValueDifference = 0;
	}

	public void Change()                                                                            //—рабатывает при изменении количества ресурсов или при улучшении
	{
		OnChange?.Invoke();
	}

	public void Effects()
	{
		Click.Play();
		Audio.Play();

		OnChange?.Invoke();
	}

	public void SetData(int watercount)																//”меньшает количество текущих ресурсов на величину передаваемой переменной
	{
		IncomeResources.Resource -= watercount;
		if (IncomeResources.Resource < 0) IncomeResources.Resource = 0;

		OnChange?.Invoke();
	}

	public void AddData(int watercount)
	{
		IncomeResources.Resource += watercount;

		OnChange?.Invoke();
	}

	public float GetData()
	{
		return IncomeResources.Resource;
	}

	public void UpgradeValue()																			//ѕоднимает уровень здани€ если достаточно монет
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];

		IncomeResources.ChangeIncomeValue(CurrentLevel.IncomePerSecondValue);

		OnUpgrade?.Invoke();
	}

	public void UpgradeTimer()
	{
		CurrentImproveLevel = improvement_levels_config.levels[CurrentImproveLevel.CurrentLevelNumber];

		IncomeResources.ChangeTime(CurrentImproveLevel.EffectValue);

		OnUpgrade?.Invoke();
	}

	public int DragResourceValue()
	{
		return CurrentLevel.DragResourceCapacity;
	}

	public BuildingLevel NextLevelValueData()															//ѕозвол€ет получить данные следующего уровн€ (»спользуетс€ дл€ магазина)
	{
		if (CurrentLevel.CurrentLevelNumber <= levels_config.levels.Count - 1) return levels_config.levels[CurrentLevel.CurrentLevelNumber];
		else return null;
	}

	public Improvement_Level_New NextLevelTimerData()
	{
		if (CurrentImproveLevel.CurrentLevelNumber <= improvement_levels_config.levels.Count - 1) return improvement_levels_config.levels[CurrentImproveLevel.CurrentLevelNumber];
		else return null;
	}
	public int GetLevelsCount()
	{
		return levels_config.levels.Count;
	}

	public int GetImprovementLevelsCount()
	{
		return improvement_levels_config.levels.Count;
	}

	void Update()                                                                                   //—рабатывает каждый кадр, отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
