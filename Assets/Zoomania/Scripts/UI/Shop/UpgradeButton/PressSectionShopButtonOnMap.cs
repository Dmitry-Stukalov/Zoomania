using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressSectionShopButtonOnMap : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private PressSectionShopButton SellShopButton;
	[field: SerializeField] private PressSectionShopButton BuyShopButton;

	public void OnPointerClick(PointerEventData eventData)
	{
		SellShopButton.DownButton();
		BuyShopButton.UpButton();
	}
}
