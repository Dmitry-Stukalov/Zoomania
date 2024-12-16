using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyRegion : MonoBehaviour, IPointerClickHandler
{
	public GameObject BuyMenu;
	public bool IsBuy;
	public void OnPointerClick(PointerEventData data)
	{
		if (!IsBuy) BuyMenu.SetActive(true);
		else Debug.Log("Этот регион уже куплен");
	}
}
