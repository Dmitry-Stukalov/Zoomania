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
	private Vector3 StartTextPosition { get; set; }

	private void Start()
	{
		StartTextPosition = Text.transform.localPosition;

		if (IsSellSection)
		{
			DownButton();
		}
		else UpButton();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		DownButton();
		AnotherButton.UpButton();
	}

	public void DownButton()
	{
		image.sprite = Press;
		Text.transform.localPosition = new Vector3(StartTextPosition.x, StartTextPosition.y - 5f, StartTextPosition.z);
	}

	public void UpButton()
	{
		image.sprite = UnPress;
		//Text.transform.position = new Vector3(StartTextPosition.x, StartTextPosition.y + 5f, StartTextPosition.z);
		Text.transform.localPosition = StartTextPosition;
	}
}
