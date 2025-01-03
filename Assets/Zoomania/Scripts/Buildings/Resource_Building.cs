using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceBuilding : MonoBehaviour, IPointerClickHandler                                    // ласс, который прикрепл€етс€ к поилке
																									   //ѕо идее работает, но нужно сделать систему уровней из которой будут братьс€ значени€ дл€ количества ресурсов в секунду и при нажатии
{
	public IncomeResource IncomeResources = new IncomeResource(1, 1);                                   //ѕеременна€ отвечающа€ за получение ресурсов

	public BuildingLevel CurrentLevel;                              //ѕеременна€ отвечающа€ за уровень и количество получаемых ресурсов

	public Building_Levels_Config levels_config;

	private MoneyPerClick moneyperclick;

	public ParticleSystem Click;
	public AudioSource Audio;

	public event Action OnChange;
	public event Action OnLevelUp;


	private void Start()
	{
		CurrentLevel = levels_config.levels[0];

		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		IncomeResources.ResourceTimer.OnTimerEnd += Change;
		UpdateData();
	}

	public void IncomePerClick()                                                                    //‘ункци€, котора€ срабатывает при активном получении ресурсов (ѕри каждом нажатии)
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

	public void Change()                                                                            //‘ункци€, котора€ срабатывает при изменении количества ресурсов или при улучшении
	{
		OnChange?.Invoke();
		UpdateData();
	}

	public void SetData(int watercount)
	{
		IncomeResources.Resource.SetValue(watercount, false);
		OnChange?.Invoke();
	}

	public int GetData()
	{
		return IncomeResources.Resource.GetValue();
	}

	public void UpdateData()                                                                        //‘ункци€, котора€ обновл€ет значени€ получаемых ресурсов
	{
		IncomeResources.IncomePerSecondValue = CurrentLevel.IncomePerSecondValue;
		IncomeResources.IncomePerClickValue = CurrentLevel.IncomePerClickValue;
	}

	public void LevelUp()
	{
		if (moneyperclick.IncomeMoney.Resource.GetValue() < CurrentLevel.MoneyForUpgrage)
		{
			Debug.Log("Ќедостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(CurrentLevel.MoneyForUpgrage);

		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];

		Change();

		OnLevelUp?.Invoke();
	}

	void Update()                                                                                   //‘ункци€, срабатывающа€ каждый кадр, котора€ отвечает за работу таймера
	{
		IncomeResources.Update(Time.deltaTime);
	}
}
