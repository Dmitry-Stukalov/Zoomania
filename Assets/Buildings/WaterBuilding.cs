using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterBuilding : MonoBehaviour, IPointerClickHandler                                    // ласс, который прикрепл€етс€ к поилке
																									//ѕо идее работает, но нужно сделать систему уровней из которой будут братьс€ значени€ дл€ количества ресурсов в секунду и при нажатии
{
	public IncomeResource IncomeWater = new IncomeResource(2, 1);                                   //ѕеременна€ отвечающа€ за получение ресурсов

	public BuildingLevel CurrentLevel = new BuildingLevel(1, 1, 1, 1);                                              //ѕеременна€ отвечающа€ за уровень и количество получаемых ресурсов

	public event Action OnChange;


	private void Start() 
	{
		IncomeWater.OnIncomePerSecond += IncomePerSecond;
		IncomeWater.ResourceTimer.OnTimerEnd += Change;
		UpdateData();
	}


	public void IncomePerSecond()                                                                   //‘ункци€, котора€ срабатывает при пассивном получении ресурсов (через каждое N количество секунд)
	{
		
	}

	public void IncomePerClick()                                                                    //‘ункци€, котора€ срабатывает при активном получении ресурсов (ѕри каждом нажатии)
	{
		IncomeWater.IncomePerClick();
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

	public void SetData(int watercount)
	{
		IncomeWater.Resource.SetValue(watercount, false);
	}

	public int GetData()
	{
		return IncomeWater.Resource.GetValue();
	}

	public void UpdateData()                                                                        //‘ункци€, котора€ обновл€ет значени€ получаемых ресурсов
	{
		IncomeWater.IncomePerSecondValue = CurrentLevel.IncomePerSecondValue;
		IncomeWater.IncomePerClickValue = CurrentLevel.IncomePerClickValue;
	}

	void Update()                                                                                   //‘ункци€, срабатывающа€ каждый кадр, котора€ отвечает за работу таймера
	{
		IncomeWater.Update(Time.deltaTime);
	}


}
