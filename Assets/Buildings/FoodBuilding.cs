using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodBuilding : MonoBehaviour, IPointerClickHandler                                     // ласс, который прикрепл€етс€ к кормушке
																									//ѕо идее работает, но нужно сделать систему уровней из которой будут братьс€ значени€ дл€ количества ресурсов в секунду и при нажатии
{
	public IncomeResource IncomeFood = new IncomeResource(1, 1);                                    //ѕеременна€ отвечающа€ за получение ресурсов

	public BuildingLevel CurrentLevel = new BuildingLevel(1, 1, 1, 1);                                              //ѕеременна€ отвечающа€ за уровень и количество получаемых ресурсов

	public event Action OnChange;


	private void Start()
	{
		IncomeFood.OnIncomePerSecond += IncomePerSecond;
		IncomeFood.ResourceTimer.OnTimerEnd += Change;
		UpdateData();
	}


	public void IncomePerSecond()                                                                   //‘ункци€, котора€ срабатывает при пассивном получении ресурсов (через каждое N количество секунд)
	{
		
	}

	public void IncomePerClick()                                                                    //‘ункци€, котора€ срабатывает при активном получении ресурсов (ѕри каждом нажатии)
	{
		IncomeFood.IncomePerClick();
		OnChange?.Invoke();
	}

	public void OnPointerClick(PointerEventData data)
	{
		IncomePerClick();
	}

	public void Change()                                                                            //‘ункци€, котора€ срабатывает при изменении количества ресурсов или при улучшении
	{
		OnChange?.Invoke();
		UpdateData();
	}

	public void SetData(int foodcount)
	{
		IncomeFood.Resource.SetValue(foodcount, false);
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


	void Update()                                                                                   //‘ункци€, срабатывающа€ каждый кадр, котора€ отвечает за работу таймера
	{
		IncomeFood.Update(Time.deltaTime);
	}

}
