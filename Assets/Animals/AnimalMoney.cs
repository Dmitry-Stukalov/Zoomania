using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalMoney : MonoBehaviour															//Этот класс пока не используется
{
	public BuildingLevel CurrentLevel = new BuildingLevel(1, 1, 1, 1);                                              //Переменная отвечающая за уровень и количество получаемых ресурсов

	public IncomeResource IncomeMoney = new IncomeResource(1, 0);                                    //Переменная отвечающая за получение ресурсов

	public event Action OnChange;

	private void Start()
	{
		IncomeMoney.ResourceTimer.OnTimerEnd += Change;
	}

	public void Change()                                                                            //Функция, которая срабатывает при изменении количества ресурсов или при улучшении
	{
		OnChange?.Invoke();
		UpdateData();
	}

	public void UpdateData()                                                                        //Функция, которая обновляет значения получаемых ресурсов
	{
		IncomeMoney.IncomePerSecondValue = CurrentLevel.IncomePerSecondValue;
		IncomeMoney.IncomePerClickValue = CurrentLevel.IncomePerClickValue;
	}

	void Update()                                                                                   //Функция, срабатывающая каждый кадр, которая отвечает за работу таймера
	{
		IncomeMoney.Update(Time.deltaTime);
	}
}
