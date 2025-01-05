using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeResource																// ласс, который отвечает за получение ресурсов через врем€ и через клики
{
	public int IncomePerSecondValue { get; set; }                                       //ѕеременна€, котора€ отвечает за количество пассивно получаемых ресурсов (через каждое N количество секунд)
	public int IncomePerClickValue { get; set; }                                        //ѕеременна€, котора€ отвечает за количество активно получаемых русурсов (ѕри каждом нажатии)

	public int Resource;																//ѕеременна€, котора€ хранит в себе текущее количество ресурсов игрока

	public event Action OnTick;															//—обытие, вызываемое каждый тик
	public event Action OnIncomePerSecond;												//—обытие, вызываемое когда происходит пассивное получение ресурсов
	public event Action OnIncomePerClick;												//—обытие, вызываемое когда происходит активное получение ресурсов (нажатие)

	public Timer ResourceTimer;															//ѕеременна€, котора€ отвечает за врем€ пассивно получаемых ресурсов

	public IncomeResource(int incomepersecondvalue, int incomeperclickvalue, int timerlength)
	{
		IncomePerSecondValue = incomepersecondvalue;
		IncomePerClickValue = incomeperclickvalue;

		ResourceTimer = new Timer(timerlength);

		ResourceTimer.OnTimerEnd += IncomePerSecond;
	}


	public void IncomePerSecond()															//‘ункци€, котора€ срабатывает при пассивном получении ресурсов (через каждое N количество секунд)
	{
		Resource += IncomePerSecondValue;
		ResourceTimer.ResetTimer(false);
		OnIncomePerSecond?.Invoke();
	}

	public void IncomePerClick()                                                            //‘ункци€, котора€ срабатывает при активном получении ресурсов (ѕри каждом нажатии)
	{
		Resource += IncomePerClickValue;
		OnIncomePerClick?.Invoke();
	}

	public void Update(float time)																	//‘ункци€, срабатывающа€ каждый кадр, котора€ отвечает за работу таймера
	{
		ResourceTimer.Tick(time);
		OnTick?.Invoke();
	}
}
