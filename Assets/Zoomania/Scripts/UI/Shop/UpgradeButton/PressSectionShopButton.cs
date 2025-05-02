using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressSectionShopButton : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private Sprite UnPress;
	[field: SerializeField] private Sprite Press;
	[field: SerializeField] private GameObject Text;
	[field: SerializeField] private PressSectionShopButton AnotherButton;
	[field: SerializeField] private bool IsSellSection;
	[field: SerializeField] private Image image;

	private void Start()
	{
		if (IsSellSection)
		{
			image.sprite = Press;
		}
		else image.sprite = UnPress;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		image.sprite = Press;
		AnotherButton.UpButton();
	}

	public void DownButton()
	{
		image.sprite = Press;
	}

	public void UpButton()
	{
		image.sprite = UnPress;
	}
}
