using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeClick : MonoBehaviour, IPointerClickHandler
{
	private Day_And_Night Night { get; set; }
	public float DayTimeSkip { get; set; }
	public float NightTimeSkip { get; set; }


	public void Start()
	{
		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();

		DayTimeSkip = 1f;
		NightTimeSkip = 1f;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("Z");

		if (Night.IsDay)
		{
			Night.DayTime.UpdateTimer(DayTimeSkip);
		}
		else
		{
			Night.NightTime.UpdateTimer(NightTimeSkip);
		}
	}
}
