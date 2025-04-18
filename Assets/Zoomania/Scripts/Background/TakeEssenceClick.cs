using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TakeEssenceClick : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] public UnityEngine.UI.Image image;
	[field: SerializeField] public Sprite daySprite;
	[field: SerializeField] public Sprite nightSprite;
	private Barn Barn { get; set; }
	private List<GameObject> Animals { get; set; }
	private List<AnimalAI_New> AnimalAI { get; set; }
	private Day_And_Night Night { get; set; }
	private float EssenceTimeSkip { get; set; }
	private float DifferenctTimeSkip { get; set; }

	public void Start()
	{
		Barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
		Barn.Spawn += UpdateList;

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();
		Night.OnDay += DaySprite;
		Night.OnNight += NightSprite;

		if (Night.IsDay) DaySprite();
		else NightSprite();

		AnimalAI = new List<AnimalAI_New>();

		EssenceTimeSkip = 2f;
	}

	public void UpdateList()
	{
		AnimalAI.Add(Barn.Animals[Barn.Animals.Count - 1].GetComponent<AnimalAI_New>());
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!Night.IsDay)
		{
			foreach (var animal in AnimalAI)
			{
				animal.ChangeTime(EssenceTimeSkip);
			}
		}
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
}
