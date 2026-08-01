using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Класс, который отвечает за получение ресурсов через время и через клики
public class IncomeResource
{
	public Timer ResourceTimer;
	public float IncomePerSecondValue { get; set; }
	public float CurrentResourceCount { get; set; }

	public event Action OnIncomePerSecond;

	public IncomeResource(float incomePerSecondValue, float timerLength)
	{
		CurrentResourceCount = 0;

		IncomePerSecondValue = incomePerSecondValue;

		ResourceTimer = new Timer(timerLength);

		ResourceTimer.OnTimerEnd += IncomePerSecond;
	}

	public void OnDisable() => ResourceTimer.OnTimerEnd -= IncomePerSecond;

	//Метод, который срабатывает при пассивном получении ресурсов (через каждое N количество секунд)
	public void IncomePerSecond()
	{
		CurrentResourceCount += IncomePerSecondValue;
		ResourceTimer.ResetTimer(false);
		OnIncomePerSecond?.Invoke();
	}

	public void Update(float time) => ResourceTimer.Tick(time);

	public void ChangeIncomeValue(float value) => IncomePerSecondValue = value;

	public void ChangeTime(float time) => ResourceTimer.SetMaxTimeAndReset(time);
}
