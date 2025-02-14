using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeResource																// ласс, который отвечает за получение ресурсов через врем€ и через клики
{
	public float IncomePerSecondValue { get; set; }                                       //ѕеременна€, котора€ отвечает за количество пассивно получаемых ресурсов (через каждое N количество секунд)
	public float Resource { get; set; }												//ѕеременна€, котора€ хранит в себе текущее количество ресурсов игрока

	public event Action OnTick;															//—обытие, вызываемое каждый тик
	public event Action OnIncomePerSecond;												//—обытие, вызываемое когда происходит пассивное получение ресурсов

	public Timer ResourceTimer;															//ѕеременна€, котора€ отвечает за врем€ пассивно получаемых ресурсов

	public IncomeResource(float incomepersecondvalue, float timerlength)
	{
		Resource = 0;

		IncomePerSecondValue = incomepersecondvalue;

		ResourceTimer = new Timer(timerlength);

		ResourceTimer.OnTimerEnd += IncomePerSecond;
	}

	public void IncomePerSecond()															//‘ункци€, котора€ срабатывает при пассивном получении ресурсов (через каждое N количество секунд)
	{
		Resource += IncomePerSecondValue;
		ResourceTimer.ResetTimer(false);
		OnIncomePerSecond?.Invoke();
	}

	public void Update(float time)															//‘ункци€, срабатывающа€ каждый кадр, котора€ отвечает за работу таймера
	{
		ResourceTimer.Tick(time);
		OnTick?.Invoke();
	}

	public void ChangeIncomeValue(float value)
	{
		IncomePerSecondValue = value;
	}

	public void ChangeTime(float time)
	{
		ResourceTimer.SetMaxTimeAndReset(time);
	}
}
