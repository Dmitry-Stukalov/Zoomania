using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day_And_Night : MonoBehaviour
{
	private Timer DayTimer { get; set; }
	private Image NightBackground { get; set; }
	private float Ratio { get; set; }
	public bool IsDay {  get; set; }


	public event Action DayChange;


	public void Start()	
	{
		Ratio = 0.039f;

		NightBackground = GameObject.FindGameObjectWithTag("Night").GetComponent<Image>();
		ChangeColorAlpha(0);

		DayTimer = new Timer(50);

		IsDay = true;
	}

	public void Day()
	{
		IsDay = true;
		DayChange?.Invoke();
	}

	public void Night()
	{
		IsDay = false;
		DayChange?.Invoke();
	}

	public void ChangeColorAlpha(float value)
	{
		Color Color = NightBackground.color;
		Color.a = value;
		NightBackground.color = Color;
	}

	public void Update()
	{
		DayTimer.Tick(Time.deltaTime);
		if (DayTimer.CurrentTime >= 20 && DayTimer.CurrentTime <= 29) ChangeColorAlpha(DayTimer.CurrentTime % 10 * Ratio + Ratio);
		if (DayTimer.CurrentTime >= 40 && DayTimer.CurrentTime <= 49) ChangeColorAlpha((10 - DayTimer.CurrentTime % 10) * Ratio - Ratio);
		if (DayTimer.CurrentTime < 30)
		{
			Day();
		}
		if (DayTimer.CurrentTime >= 30)
		{
			Night();
		}
		if (DayTimer.CurrentTime == 50) DayTimer.ResetTimer(false);
	}
}