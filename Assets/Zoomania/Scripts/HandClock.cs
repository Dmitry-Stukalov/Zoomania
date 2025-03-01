using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class HandClock : MonoBehaviour
{
	private Day_And_Night Night { get; set; }
	private float Ratio { get; set; }
	private float Angle { get; set; }

	public void Start()
	{
		Ratio = 2.77f;
		Angle = -276;

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();
		transform.rotation = Quaternion.Euler(0, 0, Angle);
	}


	public void Update()
	{
		if (Night.IsDay)
		{
			Angle = -276 - Night.DayTime.CurrentTime * Ratio;

			transform.rotation = Quaternion.Euler(0, 0, Angle);
		}
		else
		{
			Angle = -96 - Night.NightTime.CurrentTime * Ratio;

			transform.rotation = Quaternion.Euler(0, 0, Angle);
		}
	}
}
