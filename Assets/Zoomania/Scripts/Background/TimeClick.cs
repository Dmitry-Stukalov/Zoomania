using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[field: SerializeField] public Sprite UnPressButton;
	[field: SerializeField] public Sprite PressButton;
	private Image image { get; set; }
	private Day_And_Night Night { get; set; }
	public float DayTimeSkip { get; set; }
	public float NightTimeSkip { get; set; }


	public void Start()
	{
		image = GetComponent<Image>();

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();

		DayTimeSkip = 1f;
		NightTimeSkip = 1f;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		image.sprite = PressButton;

		if (Night.IsDay)
		{
			Night.DayTime.UpdateTimer(DayTimeSkip);
		}
		else
		{
			Night.NightTime.UpdateTimer(NightTimeSkip);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		image.sprite = UnPressButton;
	}
}
