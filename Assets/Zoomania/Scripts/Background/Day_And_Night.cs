using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day_And_Night : MonoBehaviour
{
	public Timer DayTime { get; set; }
	public Timer NightTime { get; set; }
	private Image NightBackground { get; set; }
	private float Ratio { get; set; }
	public bool IsDay {  get; set; }


	public event Action OnDay;
	public event Action OnNight;


	public void Start()	
	{
		Ratio = 0.078f;

		NightBackground = GameObject.FindGameObjectWithTag("Night").GetComponent<Image>();
		ChangeColorAlpha(0);

		DayTime = new Timer(65);
		DayTime.OnTimerEnd += Night;

		NightTime = new Timer(65);
		NightTime.OnTimerEnd += Day;

		IsDay = true;
	}

	public void Day()
	{
		IsDay = true;
		DayTime.ResetTimer(false);

		OnDay?.Invoke();
	}

	public void Night()
	{
		IsDay = false;
		NightTime.ResetTimer(false);

		OnNight?.Invoke();
	}

	public void ChangeColorAlpha(float value)
	{
		Color Color = NightBackground.color;
		Color.a = value;
		NightBackground.color = Color;
	}

	public void Update()
	{
		if (IsDay) DayTime.Tick(Time.deltaTime);
		if (!IsDay) NightTime.Tick(Time.deltaTime);

		if (DayTime.CurrentTime >= 61 && DayTime.CurrentTime <= 65) ChangeColorAlpha(DayTime.CurrentTime % 10 * Ratio);
		if (NightTime.CurrentTime >= 6 && NightTime.CurrentTime <= 65) ChangeColorAlpha((10 - NightTime.CurrentTime % 10) * Ratio);
	}
}