using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnOffVibration : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private Sprite OnSprite { get; set; }
	[field: SerializeField] private Sprite OffSprite { get; set; }
	private Image image { get; set; }
	private bool IsOn { get; set; }

	void Start()
	{
		IsOn = true;
		image = GetComponent<Image>();
		gameObject.GetComponent<Image>().sprite = OnSprite;
	}


	public void OnPointerClick(PointerEventData eventData)
	{
		if (IsOn)
		{
			image.sprite = OffSprite;
			IsOn = false;
		}
		else
		{
			image.sprite = OnSprite;
			IsOn = true;
		}

	}
}
