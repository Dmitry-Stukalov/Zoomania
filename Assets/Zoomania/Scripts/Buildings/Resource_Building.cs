using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceBuilding : MonoBehaviour
{
	[field: SerializeField] private Building_Levels_Config levels_config { get; set; }
	public BuildingLevel CurrentLevel { get; set; }
	public IncomeResource IncomeResources { get; set; }
	public ParticleSystem Click { get; set; }
	public AudioSource Audio {  get; set; }
	public int TimerForGetResourses { get; set; }

	public event Action OnChange;
	public event Action OnUpgrade;


	private void Start()
	{
		CurrentLevel = levels_config.levels[0];

		IncomeResources = new IncomeResource(CurrentLevel.IncomePerSecondValue, CurrentLevel.IncomePerClickValue, TimerForGetResourses);
		IncomeResources.ResourceTimer.OnTimerEnd += Change;

		TimerForGetResourses = 10;

		UpdateData();
	}

	public void Change()                                                                            //—рабатывает при изменении количества ресурсов или при улучшении
	{
		Click.Play();
		Audio.Play();
		OnChange?.Invoke();
		UpdateData();
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

	public int GetData()
	{
		return IncomeResources.Resource;
	}

	public void UpdateData()                                                                        //ќбновл€ет значени€ получаемых ресурсов
	{
		IncomeResources.IncomePerSecondValue = CurrentLevel.IncomePerSecondValue;
		IncomeResources.IncomePerClickValue = CurrentLevel.IncomePerClickValue;
	}

	public void Upgrade()																			//ѕоднимает уровень здани€ если достаточно монет
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];

		Change();

		OnUpgrade?.Invoke();
	}

	public void UpgradeTimer(int time)
	{
		TimerForGetResourses = time;

		IncomeResources.ChangeTime(TimerForGetResourses);

		OnUpgrade?.Invoke();
	}

	public BuildingLevel CurrentLevelData()                                                         //ѕозвол€ет получить данные текущего уровн€ (»спользуетс€ дл€ личного загона)
	{
		return CurrentLevel;
	}

	public int DragResourceValue()
	{
		return CurrentLevel.DragResourceCapacity;
	}

	public BuildingLevel NextLevelData()															//ѕозвол€ет получить данные следующего уровн€ (»спользуетс€ дл€ магазина)
	{
		if (CurrentLevel.CurrentLevelNumber <= levels_config.levels.Count - 1) return levels_config.levels[CurrentLevel.CurrentLevelNumber];
		else return null;
	}

	void Update()                                                                                   //—рабатывает каждый кадр, отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
