using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodBuilding : MonoBehaviour, IPointerClickHandler                                     // ласс, который прикрепл€етс€ к кормушке
																									//ѕо идее работает, но нужно сделать систему уровней из которой будут братьс€ значени€ дл€ количества ресурсов в секунду и при нажатии
{
	public IncomeResource IncomeFood = new IncomeResource(1, 1);                                    //ѕеременна€ отвечающа€ за получение ресурсов

	public BuildingLevel CurrentLevel = new BuildingLevel(1, 1, 1, 25);                                              //ѕеременна€ отвечающа€ за уровень и количество получаемых ресурсов

	private MoneyPerClick moneyperclick;

	public ParticleSystem Click;
	public AudioSource Audio;

	public event Action OnChange;
	public event Action OnLevelUp;


	private void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		IncomeFood.ResourceTimer.OnTimerEnd += Change;
		UpdateData();
	}


	public void IncomePerClick()                                                                    //‘ункци€, котора€ срабатывает при активном получении ресурсов (ѕри каждом нажатии)
	{
		IncomeFood.IncomePerClick();
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

	public void SetData(int foodcount)
	{
		IncomeFood.Resource.SetValue(foodcount, false);
		OnChange?.Invoke();
	}

	public int GetData()
	{
		return IncomeFood.Resource.GetValue();
	}

	public void UpdateData()                                                                        //‘ункци€, котора€ обновл€ет значени€ получаемых ресурсов
	{
		IncomeFood.IncomePerSecondValue = CurrentLevel.IncomePerSecondValue;
		IncomeFood.IncomePerClickValue = CurrentLevel.IncomePerClickValue;
	}

	public void LevelUp()
	{
		if (moneyperclick.IncomeMoney.Resource.GetValue() < CurrentLevel.MoneyForUpgrage)
		{
			Debug.Log("Ќедостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(CurrentLevel.MoneyForUpgrage);

		if (CurrentLevel.CurrentLevelNumber == 1) CurrentLevel = new BuildingLevel(CurrentLevel.CurrentLevelNumber + 1, CurrentLevel.IncomePerSecondValue + 4, CurrentLevel.IncomePerClickValue + 4, CurrentLevel.MoneyForUpgrage * 4);
		else CurrentLevel = new BuildingLevel(CurrentLevel.CurrentLevelNumber + 1, CurrentLevel.IncomePerSecondValue + 5, CurrentLevel.IncomePerClickValue + 5, CurrentLevel.MoneyForUpgrage * 4);

		Change();

		OnLevelUp?.Invoke();
	}
	void Update()                                                                                   //‘ункци€, срабатывающа€ каждый кадр, котора€ отвечает за работу таймера
	{
		IncomeFood.Update(Time.deltaTime);
	}

}
