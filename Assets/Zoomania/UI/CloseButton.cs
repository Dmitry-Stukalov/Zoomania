using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseButton : MonoBehaviour, IPointerClickHandler
{
	public GameObject BuyMenu;
	public GameObject NonMoney;

	public void OnPointerClick(PointerEventData data)
	{
		BuyMenu.SetActive(false);
		NonMoney.SetActive(false);
	}
}
