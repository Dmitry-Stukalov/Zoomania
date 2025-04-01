using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

	public float GetCurrentTime()
	{
		if (IsDay) return DayTime.CurrentTime;
		else return NightTime.CurrentTime;
	}

	public async Task LoadData(SaveDataClass.TimeData time)
	{
		if (time.IsDay) IsDay = true;
		else IsDay = false;

		if (IsDay)
		{
			DayTime.UpdateTimer(time.CurrentTime);
			ChangeColorAlpha(0);
		}
		else
		{
			NightTime.UpdateTimer(time.CurrentTime);
			ChangeColorAlpha(5f * Ratio);
		}
	}

	public void Update()
	{
		if (IsDay) DayTime.Tick(Time.deltaTime);
		if (!IsDay) NightTime.Tick(Time.deltaTime);

		if (DayTime.CurrentTime >= 60 && DayTime.CurrentTime <= 64) ChangeColorAlpha(DayTime.CurrentTime % 10 * Ratio + Ratio);
		if (NightTime.CurrentTime >= 60 && NightTime.CurrentTime <= 64) ChangeColorAlpha((5 - NightTime.CurrentTime % 10 - 1) * Ratio);
	}
}