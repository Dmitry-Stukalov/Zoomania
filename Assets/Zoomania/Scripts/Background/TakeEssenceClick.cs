using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TakeEssenceClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[field: SerializeField] public Sprite UnPressButton;
	[field: SerializeField] public Sprite PressButton;
	[field: SerializeField] public UnityEngine.UI.Image image;
	[field: SerializeField] public Sprite daySprite;
	[field: SerializeField] public Sprite nightSprite;
	[field: SerializeField] public AudioSource ClickSound;
	private Barn Barn { get; set; }
	private List<GameObject> Animals { get; set; }
	private List<AnimalAI_New> AnimalAI { get; set; }
	private Day_And_Night Night { get; set; }
	private float EssenceTimeSkip { get; set; }
	private float DifferenctTimeSkip { get; set; }

	//public void Start()
	//{
	//	Barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
	//	Barn.Spawn += UpdateList;

	//	Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();
	//	Night.OnDay += DaySprite;
	//	Night.OnNight += NightSprite;
	//	Night.OnLoadData += CheckSprite;

	//	AnimalAI = new List<AnimalAI_New>();

	//	EssenceTimeSkip = 2f;

	//	if (Night.IsLoadData) CheckSprite();
	//	else DaySprite();
	//}

	public void Initializing()
	{
		Barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
		Barn.Spawn += UpdateList;

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();
		Night.OnDay += DaySprite;
		Night.OnNight += NightSprite;
		Night.OnLoadData += CheckSprite;

		AnimalAI = new List<AnimalAI_New>();

		EssenceTimeSkip = 2f;

		if (Night.IsLoadData) CheckSprite();
		else DaySprite();
	}

	public void UpdateList()
	{
		AnimalAI.Add(Barn.Animals[Barn.Animals.Count - 1].GetComponent<AnimalAI_New>());
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!Night.IsDay)
		{
			ClickSound.Play();

			image.sprite = PressButton;

			foreach (var animal in AnimalAI)
			{
				animal.ChangeTime(EssenceTimeSkip);
			}
		}
	}

	public void OnPointerUp(PointerEventData eventData) 
	{
		if (!Night.IsDay) image.sprite = UnPressButton;
	}

	
	public void ChangeTimeSkip(float time, bool plus)
	{
		if (plus) EssenceTimeSkip += time;
		else EssenceTimeSkip -= time;
	}

	private void DaySprite()
	{
		image.sprite = daySprite;
	}

	private void NightSprite()
	{
		image.sprite = nightSprite;
	}

	private void CheckSprite()
	{
		if (Night.IsDay) DaySprite();
		else NightSprite();
	}
}
