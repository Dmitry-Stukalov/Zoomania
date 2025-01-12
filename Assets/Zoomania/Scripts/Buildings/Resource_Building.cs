using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceBuilding : MonoBehaviour, IPointerClickHandler
{
	public IncomeResource IncomeResources { get; set; }
	public BuildingLevel CurrentLevel { get; set; }

	public Building_Levels_Config levels_config;
	private MoneyPerClick moneyperclick { get; set; }
	private int TimerForGetResourses = 3;

	public ParticleSystem Click;
	public AudioSource Audio;

	public event Action OnChange;
	public event Action OnLevelUp;


	private void Start()
	{
		CurrentLevel = levels_config.levels[0];

		IncomeResources = new IncomeResource(CurrentLevel.IncomePerSecondValue, CurrentLevel.IncomePerClickValue, TimerForGetResourses);

		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		IncomeResources.ResourceTimer.OnTimerEnd += Change;
		UpdateData();
	}

	public void IncomePerClick()                                                                    //—рабатывает при активном получении ресурсов (ѕри каждом нажатии)
	{
		IncomeResources.IncomePerClick();
		OnChange?.Invoke();
	}

	public void OnPointerClick(PointerEventData data)
	{
		IncomePerClick();
		Click.Play();
		Audio.Play();
	}

	public void Change()                                                                            //—рабатывает при изменении количества ресурсов или при улучшении
	{
		OnChange?.Invoke();
		UpdateData();
	}

	public void SetData(int watercount)																//”меньшает количество текущих ресурсов на величину передаваемой переменной
	{
		IncomeResources.Resource -= watercount;
		if (IncomeResources.Resource < 0) IncomeResources.Resource = 0;

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

	public void LevelUp()																			//ѕоднимает уровень здани€ если достаточно монет
	{
		if (moneyperclick.IncomeMoney.Resource < CurrentLevel.MoneyForUpgrage)
		{
			Debug.Log("Ќедостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(CurrentLevel.MoneyForUpgrage);

		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];

		Change();

		OnLevelUp?.Invoke();
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
		BuildingLevel nextlevel = new BuildingLevel();
		nextlevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		return nextlevel;
	}

	void Update()                                                                                   //—рабатывает каждый кадр, отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
