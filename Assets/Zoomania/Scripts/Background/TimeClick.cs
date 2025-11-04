using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[field: SerializeField] public Sprite UnPressButton;
	[field: SerializeField] public Sprite PressButton;
	[field: SerializeField] private AudioSource ClickSound;
	private Image image { get; set; }
	private Day_And_Night Night { get; set; }
	private Timer PressTimer { get; set; }
	public float DayTimeSkip { get; set; }
	public float NightTimeSkip { get; set; }
	private bool IsPressed { get; set; } = false;


	public void Start()
	{
		image = GetComponent<Image>();

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();

		PressTimer = new Timer(0.2f);
		PressTimer.OnTimerEnd += AutoClick;

		DayTimeSkip = 1f;
		NightTimeSkip = 1f;
	}

	private void AutoClick()
	{
		if (Night.IsDay)
		{
			Night.DayTime.UpdateTimer(DayTimeSkip);
		}
		else
		{
			Night.NightTime.UpdateTimer(NightTimeSkip);
		}

		PressTimer.ResetTimer(false);
		ClickSound.Play();
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

		IsPressed = true;
		ClickSound.Play();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		image.sprite = UnPressButton;

		IsPressed = false;
		PressTimer.ResetTimer(false);
	}

	private void Update()
	{
		if (IsPressed) PressTimer.Tick(Time.deltaTime);
	}
}
